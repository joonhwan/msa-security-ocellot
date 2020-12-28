using MireroTicket.Web.Models.Api;
using System.Collections.Generic;

namespace MireroTicket.Web.Models.View
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
