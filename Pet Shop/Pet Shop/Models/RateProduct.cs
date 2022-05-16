using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models
{
    public class RateProduct
    {
        public int RateId { get; set; }
        public int ProductId { get; set; }
        public Rate Rate { get; set; }
        public Product Product { get; set; }

    }
}
