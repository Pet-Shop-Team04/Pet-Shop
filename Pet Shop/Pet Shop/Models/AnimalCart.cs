using System.Collections.Generic;

namespace Pet_Shop.Models
{
    public class AnimalCart
    {
        public int CartId { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public Cart Cart { get; set; }
    }
}
