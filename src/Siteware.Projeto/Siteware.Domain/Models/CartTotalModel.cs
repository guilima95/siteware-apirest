using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Models
{
    public class CartTotalModel
    {
        public decimal TotalBuy { get; set; }
        public List<CartModel> Cart { get; set; }
    }
}
