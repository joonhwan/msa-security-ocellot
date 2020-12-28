namespace MireroTicket.Services.ShoppingBasket.Models
{
    public class BasketDto
    {
        public string BasketId { get; set; }
        public string UserId { get; set; }
        public int ItemCount { get; set; }
        public string CouponId { get; set; }
    }
}