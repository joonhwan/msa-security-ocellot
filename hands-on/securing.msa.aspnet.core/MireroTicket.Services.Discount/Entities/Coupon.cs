namespace MireroTicket.Services.Discount.Entities
{
    public class Coupon
    {
        public string CouponId { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
    }
}