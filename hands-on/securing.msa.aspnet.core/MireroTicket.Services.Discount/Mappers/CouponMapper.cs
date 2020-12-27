using MireroTicket.Services.Discount.Entities;
using MireroTicket.Services.Discount.Models;

namespace MireroTicket.Services.Discount.Mappers
{
    public class CouponMapper
    {
        public static CouponDto From(Coupon coupon)
        {
            return new CouponDto
            {
                Amount = coupon.Amount,
                CouponId = coupon.CouponId,
                UserId = coupon.UserId
            };
        }
    }
}