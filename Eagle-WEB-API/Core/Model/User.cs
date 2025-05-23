using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        
        public string? UserAddress { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
       
        public string? UserPhone { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public string Role { get; set; } = "User";

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
