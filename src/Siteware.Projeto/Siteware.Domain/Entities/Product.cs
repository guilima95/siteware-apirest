using Siteware.Domain.Entities.Base;
using System.Collections.Generic;

namespace Siteware.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PromotionId { get; set; }

    }
}
