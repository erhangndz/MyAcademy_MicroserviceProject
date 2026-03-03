namespace ECommerce.Order.Domain.Entities
{
    public class Ordering
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
