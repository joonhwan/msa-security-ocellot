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

namespace MireroTicket.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("/api/basketevent")]
    public class BasketChangeEventController : ControllerBase
    {
        private readonly ShoppingBasketDbContext _dbContext;

        public BasketChangeEventController(ShoppingBasketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketChangeEventDto>>> GetEvents([FromQuery] DateTime fromDate,
            [FromQuery] int max)
        {
            var events = await _dbContext
                    .BasketChangeEvents
                    .Where(@event => DbDateTime.From(@event.InsertedAt) > fromDate)
                    .OrderBy(@event => @event.InsertedAt)
                    .Take(max)
                    .ToListAsync()
                ;
            return Ok(events.Select(BasketChangeEventDtoMapper.From));
        }
    }

    
}