using System;
using System.Collections.Generic;

namespace MireroTicket.Services.EventCatalog.Entities
{
    public class Category
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public List<Event> Events { get; set; }
    }
}