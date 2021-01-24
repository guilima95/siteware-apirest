﻿using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.API.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<PromotionViewModel> Promotions { get; set; }
    }
}
