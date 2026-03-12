using ECommerce.Basket.DTOs;
using ECommerce.Basket.Settings;
using System.Text.Json;

namespace ECommerce.Basket.Services
{
    public class BasketService(RedisService _redisService) : IBasketService
    {
        public async Task DeleteBasketAsync(string userId)
        {
          await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userId)
        {
            var basket = await _redisService.GetDb().StringGetAsync(userId);
            if(basket.IsNull)
            {
                throw new Exception("Basket Not Found");
            }

            return JsonSerializer.Deserialize<BasketTotalDto>(basket);

        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
