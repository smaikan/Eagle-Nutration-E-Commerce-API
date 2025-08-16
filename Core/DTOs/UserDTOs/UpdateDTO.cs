using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.UserDTOs
{
    public class UpdateDTO
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        public AddressDTO? UserAddress { get; set; } = null;
        public string? UserPhone { get; set; } = null;
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]

        public string Password { get; set; }
    }

    public class AddressDTO
    {
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Neighbor { get; set; }
        public string? Address { get; set; }
    }
}