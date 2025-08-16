using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;

namespace Core.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
      
        public string UserName {  get; set; }   
        public string Email { get; set; }
         [Required]
        public string UserPassword { get; set; }
        public string? UserPhone { get; set; }
        public AddressDTO? UserAddress { get; set; }
         public ICollection<Order> Orders { get; set; }
        public string Role { get; set; } = "user";
    }
}
