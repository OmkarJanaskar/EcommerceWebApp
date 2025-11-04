using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        // Foreign Key
        public int? RoleId { get; set; }
        public Role? Role { get; set; }

        // Relationships
        public ICollection<Order>? Orders { get; set; }
    }
}
