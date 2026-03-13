using ECommerce.Discount.Business.DTOs.Coupons;
using ECommerce.Discount.DataAccess.Repositories.Coupons;
using ECommerce.Discount.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.Business.Services.Coupons
{
    public class CouponService(ICouponRepository _couponRepository, IValidator<Coupon> _validator) : ICouponService
    {
        public async Task CreateAsync(CreateCouponDto createCouponDto)
        {
            var coupon = createCouponDto.Adapt<Coupon>();
            var result = await _validator.ValidateAsync(coupon);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            await _couponRepository.CreateAsync(coupon);
        }

        public async Task DeleteAsync(int id)
        {
            var coupon = await _couponRepository.GetByIdAsync(id);
            if(coupon is null)
            {
                throw new ArgumentNullException($"{id} numaralı ID'ye ait Kupon Bulunamadı");
            }

            await _couponRepository.DeleteAsync(coupon);
        }

        public async Task<List<ResultCouponDto>> GetAllAsync()
        {
            var coupons = await _couponRepository.GetAllAsync();
            return coupons.Adapt<List<ResultCouponDto>>();
        }

        public async Task<ResultCouponDto> GetByIdAsync(int id)
        {
            var coupon = await _couponRepository.GetByIdAsync(id);
            if (coupon is null)
            {
                throw new ArgumentNullException($"{id} numaralı ID'ye ait Kupon Bulunamadı");
            }

            return coupon.Adapt<ResultCouponDto>();
        }

        public async Task<ResultCouponDto> GetCouponByCodeAsync(string code)
        {
           var coupon = await _couponRepository.GetQueryable().FirstOrDefaultAsync(x=>x.Code==code);
            if (coupon is null)
            {
                throw new ArgumentNullException($"{code} Kodlu bir kupon Bulunamadı");
            }

            return coupon.Adapt<ResultCouponDto>();
        }

        public async Task UpdateAsync(UpdateCouponDto updateCouponDto)
        {
            var coupon = await _couponRepository.GetByIdAsync(updateCouponDto.Id);
            if (coupon is null)
            {
                throw new ArgumentNullException($"{updateCouponDto.Id} numaralı ID'ye ait Kupon Bulunamadı");
            }

            coupon = updateCouponDto.Adapt(coupon);

            await _couponRepository.UpdateAsync(coupon);
        }
    }
}
