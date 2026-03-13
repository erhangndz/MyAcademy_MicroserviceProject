using ECommerce.Discount.Business.DTOs.Coupons;
using ECommerce.Discount.Business.Services.Coupons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CouponsController(ICouponService _couponService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coupons = await _couponService.GetAllAsync();
            return Ok(coupons);
        }

        [HttpGet("byCode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var coupon = await _couponService.GetCouponByCodeAsync(code);
            return Ok(coupon);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coupon = await _couponService.GetByIdAsync(id);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto createCouponDto)
        {
            await _couponService.CreateAsync(createCouponDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto updateCouponDto)
        {
            await _couponService.UpdateAsync(updateCouponDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _couponService.DeleteAsync(id);
            return NoContent();
        }
    }
}
