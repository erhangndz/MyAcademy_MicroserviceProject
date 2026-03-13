namespace ECommerce.Discount.Business.DTOs.Coupons;

public record CreateCouponDto(string Code, int DiscountRate, DateTime ExpireDate);

