using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.UserDTOs;

namespace Core.DTOs.OrderDTOs
{
    public class OrderCreateDTO
    {
        [Required]
        public int UserId { get; set; }

     
        public AddressDTO ShippingAddress { get; set; }

        public List<OrderDetailCreateDTO> OrderDetails { get; set; }
    }
}
