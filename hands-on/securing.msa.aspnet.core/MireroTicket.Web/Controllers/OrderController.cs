using System;
using System.Linq;
using System.Security.Claims;
using MireroTicket.Web.Models;
using MireroTicket.Web.Models.View;
using MireroTicket.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using MireroTicket.Utilities;

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
            //User.TryGetClaim(ClaimTypes.NameIdentifier, out Guid userId);
            User.TryGetClaim(JwtClaimTypes.Subject, out Guid userId);
            var orders = await orderService.GetOrdersForUser(userId);

            return View(new OrderViewModel { Orders = orders });
        }
    }
}
