using ECommerce.WebUI.Services.DiscountServices.CouponServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CouponController(ICouponService _couponService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var coupons = await _couponService.GetAllAsync();
            return View(coupons);
        }
    }
}
