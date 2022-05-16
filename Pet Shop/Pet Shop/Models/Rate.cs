using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models
{
    public class Rate
    {
        public int RateId { get; set; }
        public int UserId { get; set; }
        public int RateValue { get; set; }
        public List<RateProduct> Ratings{ get; set; }

     //   public  ApplicationUser AppUser { get; set; }
}
}
