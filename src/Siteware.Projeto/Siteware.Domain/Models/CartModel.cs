using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Models
{
    public class CartModel
    {
        public string NameProduct { get; set; }
        public int QuantityProduct { get; set; }
        public decimal PriceTotal { get; set; }
        public string Promotion { get; set; }
}
}
