using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MireroTicket.Services.EventCatalog.DbContexts;
using MireroTicket.Services.EventCatalog.Entities;
using MireroTicket.Services.EventCatalog.Models;

namespace MireroTicket.Services.EventCatalog.Controllers
{
    [Route("api/categories")]
    // [Authorize] // --> 원래여기에.. 하지만, Global하게 할 수 있어서 주석처리함.
    public class CategoryController : ControllerBase
    {
        private readonly EventCatalogContext _context;

        public CategoryController(EventCatalogContext context)
        {
            _context = context;
        }
        
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            return await _context
                    .Categories
                    .Select(category => new CategoryDto
                    {
                        Name = category.Name,
                        CategoryId = category.CategoryId,
                    }).ToListAsync()
                ;
        }
    }
}