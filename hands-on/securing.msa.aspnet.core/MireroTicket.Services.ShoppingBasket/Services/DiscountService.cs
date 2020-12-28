using System.Net.Http;
using System.Threading.Tasks;
using MireroTicket.Services.Common;
using MireroTicket.Services.ShoppingBasket.Models;

namespace MireroTicket.Services.ShoppingBasket.Services
{
    public class DiscountService
    {
        private readonly HttpClient _client;

        public DiscountService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Coupon> GetCouponAsync(string userId)
        {
            var response = await _client.GetAsync($"/api/discount/user/{userId}");
            
            // Coupon 이 없다고 오류는 아님. 없을 수도 있음. 
            //  --> ReadContentAs<T>() 는 잘못된 response에 대해서 throw하기 때문에, 여기서 오류처리.
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            
            return await response.ReadContentAs<Coupon>();
        }
    }
}