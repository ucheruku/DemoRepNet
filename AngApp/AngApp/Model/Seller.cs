using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngApp.Model
{
    public class Seller
    {
        public int? SellerId { get; set; }

        public string SellerNumber { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }       

        public DateTime? DateSold { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}