using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MireroTicket.Services.EventCatalog.DbContexts;
using MireroTicket.Services.EventCatalog.Mappers;
using MireroTicket.Services.EventCatalog.Models;

namespace MireroTicket.Services.EventCatalog.Controllers
{
    // [Authorize(Policy = "CanRead")]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly EventCatalogContext _context;

        public EventController(EventCatalogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> Get()
        {
            var result =
                    await _context
                        .Events
                        .Include(e => e.Category)
                        .Select(e => EventMapper.From(e))
                        .ToListAsync()
                ;
            return result;
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventDto>> GetById(string eventId)
        {
            var e = await _context
                    .Events
                    .Include(e => e.Category)
                    .FirstOrDefaultAsync(e => e.EventId == eventId)
                ;
            return EventMapper.From(e);
        }
    }
}