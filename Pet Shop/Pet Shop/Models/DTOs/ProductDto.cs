using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.DTO
{
    public class ProductDto
    {
        public int ProdactId { get; set; }
        public string Name { get; set; }
        public string AnimalType { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public double RatingAverage { get; set; }
        public List<RateProduct> Ratings { get; set; }
       // public RateOne { get; set; }

    }
}
