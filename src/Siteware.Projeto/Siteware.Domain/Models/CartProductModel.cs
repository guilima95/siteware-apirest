using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Models
{
    public class CartProductModel
    {
        public decimal PriceTotal { get; set; }
        public ProductCartModel Product { get; set; }

        public string PromotionDescription { get; set; }
    }
}
