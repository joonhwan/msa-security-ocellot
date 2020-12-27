using System;
using Microsoft.EntityFrameworkCore;
using MireroTicket.Services.Common;
using MireroTicket.Services.Discount.Entities;

namespace MireroTicket.Services.Discount.DbContexts
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options)
            : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.NewGuid().ToDbString(), 
                Amount = 10, 
                UserId = Guid.Parse("{E455A3DF-7FA5-47E0-8435-179B300D531F}").ToDbString(),
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.NewGuid().ToDbString(), 
                Amount = 20, 
                UserId = Guid.Parse("{bbf594b0-3761-4a65-b04c-eec4836d9070}").ToDbString()
            }); 
        }
    }
}