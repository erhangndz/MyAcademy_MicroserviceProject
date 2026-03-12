namespace ECommerce.Discount.Entity.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountRate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
