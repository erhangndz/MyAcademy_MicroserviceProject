namespace ECommerce.Basket.DTOs
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string? DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public IList<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice => BasketItems.Sum(x => x.Price * x.Quantity);
    }
}
