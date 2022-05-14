using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pet_Shop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string AnimalType { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        public List<CartProduct> CartProducts { get; set; }

    }
}
