using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Models
{
    public class ProductCartModel
    {
        public string NameProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public int Quantity { get; set; }
        public TypePromotion? TypePromotion { get; set; }

    }
}
