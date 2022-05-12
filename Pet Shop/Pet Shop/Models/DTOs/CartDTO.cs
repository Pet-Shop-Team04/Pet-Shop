using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.DTO
{
    public class CartDTO
    {


        public int CartId { get; set; }
        public int TotalPrice { get; set; }
        public int Count { get; set; }


        public List<AnimalDto> AnimalCarts { get; set; }
        public List<AnimalProductDto> CartAnimalProducts { get; set; }
    }
}
