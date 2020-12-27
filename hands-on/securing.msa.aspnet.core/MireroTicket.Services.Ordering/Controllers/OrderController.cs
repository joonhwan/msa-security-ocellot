using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MireroTicket.Services.Ordering.DbContexts;
using MireroTicket.Services.Ordering.Entities;

namespace MireroTicket.Services.Ordering.Controllers
{
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly OrderingDbContext _dbContext;

        public OrderController(OrderingDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<string> Health()
        {
            return "Good";
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Order>> GetOrderByUserId(string userId)
        {
            var orders = await _dbContext.Orders.Where(order => order.UserId == userId).ToListAsync();
            return Ok(orders);
        }
    }
}