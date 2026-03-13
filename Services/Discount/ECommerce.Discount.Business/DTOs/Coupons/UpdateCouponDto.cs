namespace ECommerce.Discount.Business.DTOs.Coupons;

public record UpdateCouponDto(int Id, string Code, int DiscountRate, DateTime ExpireDate);

