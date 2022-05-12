using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.DTO
{
    public class AnimalProductDto
    {


        public int AnimalProdactId { get; set; }
        public string ItemName { get; set; }
        public string AnimalType { get; set; }
        public int ItemPrice { get; set; }
        public string ItemDescription { get; set; }


    }
}
