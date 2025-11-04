namespace ECommerceAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string ImageUrl { get; set; }
        // Relationships
        public ICollection<Product> Products { get; set; }
    }
}
    