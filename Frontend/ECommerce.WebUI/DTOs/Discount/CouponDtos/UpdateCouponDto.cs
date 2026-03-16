namespace ECommerce.WebUI.DTOs.Discount.CouponDtos
{
    public class UpdateCouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountRate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
