namespace MireroTicket.Services.ShoppingBasket.Models
{
    // Discount 서비스 연동.
    public class Coupon
    {
        public string CouponId { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public bool AlreadyUsed { get; set; }
    }
}