using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.DTOs
{
    public class AnimalForCartDto
    {

        public int AnimalId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
