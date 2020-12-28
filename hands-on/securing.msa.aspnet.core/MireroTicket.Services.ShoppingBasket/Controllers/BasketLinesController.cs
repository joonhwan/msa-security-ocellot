using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MireroTicket.Services.Common;
using MireroTicket.Services.ShoppingBasket.DbContexts;
using MireroTicket.Services.ShoppingBasket.Entities;
using MireroTicket.Services.ShoppingBasket.Mappers;
using MireroTicket.Services.ShoppingBasket.Models;
using MireroTicket.Services.ShoppingBasket.Services;

namespace MireroTicket.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("/api/baskets/{basketId}/basketlines")]
    public class BasketLinesController : ControllerBase
    {
        private readonly ShoppingBasketDbContext _dbContext;
        private readonly EventCatalogService _eventCatalogService;

        public BasketLinesController(ShoppingBasketDbContext dbContext, EventCatalogService eventCatalogService)
        {
            _dbContext = dbContext;
            _eventCatalogService = eventCatalogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketLineDto>>> Get(string basketId)
        {
            // basket이 없어서 basketLine 이 없는 건지, 아니면, basket이 없는건지 구별.
            if (!await _dbContext.Baskets.AnyAsync(basket => basket.Id == basketId))
            {
                return NotFound();
            }

            var entities = await _dbContext
                .BasketLines
                .Include(line => line.Event)
                .Where(line => line.BasketId == basketId)
                .ToListAsync()
                ;
            var dtoList = entities.Select(BasketLineDtoMapper.From);
            return Ok(dtoList);
        }

        [HttpGet("{basketLineId}", Name = "GetBasketLine")]
        public async Task<ActionResult<BasketLineDto>> GetBasketLineById(string basketId, string basketLineId)
        {
            // basket이 없어서 basketLine 이 없는 건지, 아니면, basket이 없는건지 구별.
            if (!await _dbContext.Baskets.AnyAsync(basket => basket.Id == basketId))
            {
                return NotFound();
            }

            var entity = await _dbContext
                    .BasketLines
                    .Include(line => line.Event)
                    .Where(line => line.Id == basketLineId)
                    .FirstOrDefaultAsync()
                ;
            if(entity == null)
            {
                return NotFound();
            }

            var dto = BasketLineDtoMapper.From(entity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<BasketLine>> CreateBasketLine(
            string basketId,
            [FromBody] BasketLineForCreation basketLineForCreation
        )
        {
            // basket이 없어서 basketLine 이 없는 건지, 아니면, basket이 없는건지 구별.
            var basket = await _dbContext.Baskets.FirstOrDefaultAsync(b => b.Id == basketId);
            if (basket == null)
            {
                return NotFound();
            }

            // BasketLine과 관련된 Event 데이터를 끌어와서 저장 
            // 
            // [마이크로서비스]
            // - Events 가 서비스 2군데서 중복 저장하고 있다. 
            // - 의존성이 없다고 하지만, 결국, EventCatalogService에 의존적 (CQRS 적용이 필요?!)
            var @event =
                await _dbContext.Events.FirstOrDefaultAsync(@event => @event.Id == basketLineForCreation.EventId); 
            if (@event == null)
            {
                var eventFromCatalog = await _eventCatalogService.GetEvent(basketLineForCreation.EventId);
                await _dbContext.Events.AddAsync(eventFromCatalog);
                await _dbContext.SaveChangesAsync();

                @event = eventFromCatalog;
            }

            var basketLineEntity = await _dbContext
                    .BasketLines
                    .Include(line => line.Event)
                    .Where(line => line.EventId == basketLineForCreation.EventId && line.BasketId == basketId)
                    .FirstOrDefaultAsync()
                ;
            if (basketLineEntity == null)
            {
                basketLineEntity = BasketLineEntityMapper.From(basketId, basketLineForCreation);
                basketLineEntity.Id = Guid.NewGuid().ToDbStringId();
                basketLineEntity.Event = @event;
                await _dbContext.BasketLines.AddAsync(basketLineEntity);
            }
            else
            {
                basketLineEntity.TicketAmount += basketLineForCreation.TicketAmount;
            }
            await _dbContext.SaveChangesAsync();

            // event repo
            var basketChangeEvent = new BasketChangeEvent()
            {
                Id = Guid.NewGuid().ToDbStringId(),
                EventId = basketLineForCreation.EventId,
                InsertedAt = DateTime.Now.ToDbDateTimeString(),
                UserId = basket.UserId,
                BasetChangeType = BasketChangeTypeEnum.Add
            };
            await _dbContext.BasketChangeEvents.AddAsync(basketChangeEvent);
            await _dbContext.SaveChangesAsync();
            
            var basketLineDto = BasketLineDtoMapper.From(basketLineEntity);
            return CreatedAtRoute(
                "GetBasketLine",
                new
                {
                    basketId = basket.Id,
                    basketLineId = basketLineEntity.Id,
                },
                basketLineDto
            );
        }

        [HttpPut("{basketLineId}")]
        public async Task<ActionResult<BasketLineDto>> Update(
            string basketId,
            string basketLineId,
            [FromBody] BasketLineForUpdate basketLineForUpdate
        )
        {
            if (!await _dbContext.BasketLines.AnyAsync(line => line.BasketId == basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await _dbContext
                .BasketLines
                .Include(line => line.Event)
                .FirstOrDefaultAsync(line => line.Id == basketLineId)
                ;
            if (basketLineEntity == null)
            {
                return NotFound();
            }

            basketLineEntity.TicketAmount = basketLineForUpdate.TicketAmount;
            await _dbContext.SaveChangesAsync();

            return Ok(BasketLineDtoMapper.From(basketLineEntity));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string basketId, string basketLineId)
        {
            var basket = await _dbContext.Baskets.FirstOrDefaultAsync(basket => basket.Id == basketId);
            if (basket == null)
            {
                return NotFound();
            }

            var basketLineEntity = await _dbContext
                    .BasketLines
                    .Include(line => line.Event)
                    .FirstOrDefaultAsync(line => line.Id == basketLineId)
                ;
            if (basketLineEntity == null)
            {
                return NotFound();
            }
            _dbContext.Remove(basketLineEntity);
            await _dbContext.SaveChangesAsync();
            
            // publish removal event
            var basketChangeEvent = new BasketChangeEvent()
            {
                Id = basketLineEntity.Id,
                EventId = basketLineEntity.EventId,
                InsertedAt = DateTime.Now.ToDbDateTimeString(),
                UserId = basket.UserId,
                BasetChangeType = BasketChangeTypeEnum.Remove
            };
            await _dbContext.AddAsync(basketChangeEvent);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }

}