using Siteware.Domain.Entities.Base;
using Siteware.Domain.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siteware.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int PromotionId { get; private set; }
        [NotMapped]
        public IList<Promotion> Promotions { get; set; }


        public Product()
        {

        }

        public Product(string name, decimal price, int promotionId)
        {
            Name = name;
            Price = price;
            PromotionId = promotionId;

            Validate(this, new ProductValidations());

            NewProductItem(name, price, promotionId);
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        Product NewProductItem(string name, decimal price, int promotionId)
        {
            return new Product
            {
                Name = name,
                Price = price,
                PromotionId = promotionId
            };
        }
    }
}
