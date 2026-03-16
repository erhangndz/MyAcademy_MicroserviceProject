namespace ECommerce.WebUI.DTOs.Discount.CouponDtos
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public int DiscountRate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
