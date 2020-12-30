using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MireroTicket.ServiceBus;
using MireroTicket.Services.Common;
using MireroTicket.Services.ShoppingBasket.DbContexts;
using MireroTicket.Services.ShoppingBasket.Entities;
using MireroTicket.Services.ShoppingBasket.Mappers;
using MireroTicket.Services.ShoppingBasket.Messages;
using MireroTicket.Services.ShoppingBasket.Models;
using MireroTicket.Services.ShoppingBasket.Services;
using MireroTicket.Utilities;

namespace MireroTicket.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("/api/baskets")]
    public class BasketsController : ControllerBase
    {
        private readonly ShoppingBasketDbContext _dbContext;
        private readonly DiscountService _discountService;
        private readonly IMessageProducer<BasketCheckoutMessage> _producer;

        public BasketsController(
            ShoppingBasketDbContext dbContext,
            DiscountService discountService,
            IMessageProducer<BasketCheckoutMessage> producer
        )
        {
            _dbContext = dbContext;
            _discountService = discountService;
            _producer = producer;
        }

        // 내가 그냥 넣어본거. 
        [HttpGet]
        public async IAsyncEnumerable<BasketDto> GetAll()
        {
            var entities = await _dbContext
                    .Baskets
                    .Include(basket => basket.BasketLines)
                    .ToListAsync()
                ;
            foreach (var entity in entities)
            {
                var dto = BasketDtoMapper.From(entity);
                yield return dto;
            }
        }

        [HttpGet("{basketId}", Name="GetBasket")] // CreatedAtRoute() 메소드에서 사용할 수 있는 Name 
        public async Task<ActionResult<BasketDto>> GetBasket(string basketId)
        {
            var entity = await _dbContext
                    .Baskets
                    .Include(basket => basket.BasketLines)
                    .Where(basket => basket.Id == basketId)
                    .FirstOrDefaultAsync()
                ;
            if (entity == null)
            {
                return NotFound();
            }

            var dto = BasketDtoMapper.From(entity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateBasket(BasketForCreation basketForCreation)
        {
            var entity = new Basket
            {
                Id = Guid.NewGuid().ToDbStringId(),
                UserId = basketForCreation.UserId,
                BasketLines = new List<BasketLine>(),
            };
            await _dbContext.Baskets.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            var dto = BasketDtoMapper.From(entity);
            return CreatedAtRoute("GetBasket", new { basketId = entity.Id }, dto);
        }

        [HttpPost("checkout")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CheckoutBasket([FromBody] BasketCheckout basketCheckout)
        {
            try
            {
                var entity = await _dbContext
                        .Baskets
                        .Include(basket => basket.BasketLines)
                        .Where(basket => basket.Id == basketCheckout.BasketId)
                        .FirstOrDefaultAsync()
                    ;
                if (entity == null)
                {
                    return BadRequest(); // not NotFound() 
                }
                //var userId = HttpContext.Request.Headers["CurrentUser"].FirstOrDefault(); // basketCheckout.UserId;
                var userId = User.GetClaimOrDefault<string>("sub");
                if (!userId.IsValidDbStringId())
                {
                    return BadRequest("No Valid 'CurrentUser' Header exists");
                }

                var basketCheckoutMessage = BasketCheckoutMessageMapper.From(basketCheckout, userId);
                basketCheckoutMessage
                    .BasketLines
                    .AddRange(entity
                        .BasketLines
                        .Select(line =>
                            new BasketLineMessage()
                            {
                                Price = line.Price,
                                TicketAmount = line.TicketAmount,
                                BasketLineId = line.Id,
                            }
                        )
                    );

                int totalPrice =
                    basketCheckoutMessage
                        .BasketLines
                        .Sum(lineMessage =>
                            lineMessage.Price * lineMessage.TicketAmount
                        );
                
                // Discount서버를 통해 할인 적용.
                var coupon = userId.IsValidDbStringId() ? await _discountService.GetCouponAsync(userId) : null;
                var couponAmount = coupon?.Amount ?? 0;
                
                // 지불금액 
                basketCheckoutMessage.BasketTotal = totalPrice - couponAmount;

                // 다른 서비스(~= Order Service) 에 Checkout 되었음을 통지. 
                await _producer.Produce(basketCheckoutMessage);

                // 처리된 Basket 을 삭제.
                var basketsToRemove = _dbContext.Baskets.Where(basket => basket.Id == basketCheckout.BasketId);
                _dbContext.Baskets.RemoveRange(basketsToRemove);
                await _dbContext.SaveChangesAsync();

                return Ok(basketCheckoutMessage);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.StackTrace);
            }
        }
    }
}