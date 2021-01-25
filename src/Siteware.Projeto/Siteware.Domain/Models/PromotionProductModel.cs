﻿using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Models
{
    public class PromotionProductModel
    {
        public int PromotionId { get; set; }
        public string DescriptionPromotion { get; set; }

        public TypePromotion TypePromotion { get; set; }

        public StatusPromotion StatusPromotion { get; set; }
    }
}
