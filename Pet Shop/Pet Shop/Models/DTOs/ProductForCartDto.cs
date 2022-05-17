using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.DTOs
{
    public class ProductForCartDto
    {
        public int ProdactId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int Amount { get; set; }

    }
}
