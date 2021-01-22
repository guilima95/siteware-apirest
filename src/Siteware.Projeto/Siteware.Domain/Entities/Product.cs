using Siteware.Domain.Entities.Base;

namespace Siteware.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
