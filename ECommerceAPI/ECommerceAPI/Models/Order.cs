namespace ECommerceAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        // Foreign Key
        public int UserId { get; set; }
        public User User { get; set; }

        // Relationships
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
