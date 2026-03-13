using ECommerce.Discount.Business.DTOs.Coupons;

namespace ECommerce.Discount.Business.Services.Coupons
{
    public interface ICouponService
    {

        Task<ResultCouponDto> GetCouponByCodeAsync(string code);
        Task<List<ResultCouponDto>> GetAllAsync();
        Task<ResultCouponDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCouponDto createCouponDto);
        Task UpdateAsync(UpdateCouponDto updateCouponDto);
        Task DeleteAsync(int id);
    }
}
