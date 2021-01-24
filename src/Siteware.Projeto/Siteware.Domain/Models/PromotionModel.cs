using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Models
{
    public class PromotionModel
    {
        public TypePromotion Type { get; set; }
        public StatusPromotion Status { get; set; }
        public string DescriptionPromotion { get; set; }
    }
}
