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
        [ForeignKey("PromotionId")]
        public int PromotionId { get; set; }

        [NotMapped]
        public IList<Promotion> Promotions { get; set; }


        public Product()
        {

        }

        public Product(string name, decimal price, int? promotionId = null)
        {
            Name = name;
            Price = price;
            PromotionId = promotionId.Value;

            Validate(this, new ProductValidations());

            NewProductItem(name, price, promotionId);
        }


        Product NewProductItem(string name, decimal price, int? promotionId = null)
        {
            return new Product
            {
                Name = name,
                Price = price,
                PromotionId = promotionId.Value
            };
        }
    }
}
