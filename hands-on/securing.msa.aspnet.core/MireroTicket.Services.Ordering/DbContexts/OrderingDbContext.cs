using Microsoft.EntityFrameworkCore;
using MireroTicket.Services.Ordering.Entities;

namespace MireroTicket.Services.Ordering.DbContexts
{
    public class OrderingDbContext : DbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options)
        : base(options)
        {
            
        }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}