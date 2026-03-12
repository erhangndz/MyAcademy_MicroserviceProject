using ECommerce.Basket.DTOs;
using ECommerce.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketsController(IBasketService _basketService) : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBasket(string userId)
        {
            var basket = await _basketService.GetBasketAsync(userId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _basketService.SaveBasketAsync(basketTotalDto);
            return Created();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteBasket(string userId)
        {
            await _basketService.DeleteBasketAsync(userId);
            return NoContent();
        }

    }
}
