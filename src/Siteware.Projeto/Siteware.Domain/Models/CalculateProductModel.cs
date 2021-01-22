using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Models
{
    public class CalculateProductModel
    {
        public string NameProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public Promotion Promotion { get; set; }
    }
}
