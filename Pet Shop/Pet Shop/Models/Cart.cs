using System.Collections.Generic;

namespace Pet_Shop.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int TotalPrice { get; set; }
        public int Count { get; set; }


        public int UserId { get; set; }
        public User Users { get; set; }
        public List<AnimalCart> AnimalCarts { get; set; }
        public List<CartAnimalProduct> CartAnimalProducts { get; set; }

    }
}
