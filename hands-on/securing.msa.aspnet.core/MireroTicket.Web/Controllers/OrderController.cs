using MireroTicket.Web.Models;
using MireroTicket.Web.Models.View;
using MireroTicket.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MireroTicket.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly Settings settings;

        public OrderController(Settings settings, IOrderService orderService)
        {
            this.settings = settings;
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetOrdersForUser(settings.UserId);

            return View(new OrderViewModel { Orders = orders });
        }
    }
}
