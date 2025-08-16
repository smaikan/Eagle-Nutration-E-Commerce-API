using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }

        public Address? UserAddress { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        public string? UserPhone { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public string Role { get; set; } = "User";
        public Cart Cart { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
[Owned] 
    public class Address
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighbor { get; set; }
        public string? Addressc { get; set; }
    }
}
