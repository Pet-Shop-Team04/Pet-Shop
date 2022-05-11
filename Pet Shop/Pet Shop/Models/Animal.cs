using System;
using System.Collections.Generic;

namespace Pet_Shop.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfBerth { get; set; }
        public string AnimalType { get; set; }

        public List<AnimalEvent> AnimalEvents { get; set; }
        public List<AnimalCart> AnimalCarts { get; set; }

    }
}
