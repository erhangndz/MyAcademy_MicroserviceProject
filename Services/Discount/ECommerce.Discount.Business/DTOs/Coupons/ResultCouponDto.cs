namespace ECommerce.Discount.Business.DTOs.Coupons
{
    public record ResultCouponDto(int Id, string Code, int DiscountRate, DateTime ExpireDate);
   
}
