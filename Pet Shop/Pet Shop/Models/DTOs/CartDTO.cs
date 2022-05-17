using Pet_Shop.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.DTO
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public decimal TotalPrice { get; set; }
       // public int Count { get; set; }

        public List<AnimalForCartDto> Animals { get; set; }

        public List<ProductForCartDto> Products { get; set; }
    }
}
