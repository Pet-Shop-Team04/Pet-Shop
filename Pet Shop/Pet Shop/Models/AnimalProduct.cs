﻿using System.ComponentModel.DataAnnotations;

namespace Pet_Shop.Models
{
    public class AnimalProduct
    {

        [Key]
        public int AnimalProdactId { get; set; }
        public string ItemName { get; set; }
        public string AnimalType { get; set; }
        public int ItemPrice { get; set; }
        public string ItemDescription { get; set; }
        public string ItemType { get; set; }
        public int Count { get; set; }

    }
}
