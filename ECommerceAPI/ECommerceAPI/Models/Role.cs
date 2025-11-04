namespace ECommerceAPI.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        // Relationships
        public ICollection<User> Users { get; set; }
    }
}
