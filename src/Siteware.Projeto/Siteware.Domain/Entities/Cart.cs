using Siteware.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Entities
{
    public class Cart : Entity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}