using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MireroTicket.Services.Discount.DbContexts;
using MireroTicket.Services.Discount.Mappers;
using MireroTicket.Services.Discount.Models;

namespace MireroTicket.Services.Discount.Controllers
{
    [Route("api/discount")]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountContext _context;

        public DiscountController(DiscountContext context)
        {
            _context = context;
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<CouponDto>>> GetAllDiscounts()
        // {
        //     var entities = await _context.Coupons.ToListAsync();
        //
        //     var coupons = entities.Select(CouponMapper.From);
        //
        //     return Ok(coupons);
        // }

        [HttpGet("{couponId}")]
        public async Task<ActionResult<CouponDto>> GetDiscountById(string couponId)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponId == couponId);
            if (coupon == null)
            {
                return NotFound();
            }

            return Ok(CouponMapper.From(coupon)); 
            // 또는
            //    return CouponMapper.From(coupon);
            // (ActionResult<T> 는 implicit cast operator 가 있다)
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<CouponDto>> GetDiscountByUser(string userId)
        {
            var coupon =  await _context.Coupons.FirstOrDefaultAsync(c => c.UserId == userId);
            if (coupon == null)
            {
                return NotFound();
            }
            return Ok(CouponMapper.From(coupon));
        }
    }
}