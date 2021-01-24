using Siteware.Domain.Entities.Base;
using Siteware.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siteware.Domain.Entities
{
    public class Promotion : Entity
    {
        public Promotion()
        {

        }

        public Promotion(string description, TypePromotion typePromotion, StatusPromotion statusPromotion)
        {
            Description = description;
            TypePromotion = typePromotion;
            StatusPromotion = statusPromotion;

            Validate(this, new PromotionValidations());

            NewPromotionItem(description, typePromotion, statusPromotion);
        }

        public string Description { get; private set; }
        public TypePromotion TypePromotion { get; private set; }
        public StatusPromotion StatusPromotion { get; private set; }

        // Propriedades somente para visualização:
        [NotMapped]
        public string Status { get; set; }
        [NotMapped]
        public string Name { get; set; }
        public ICollection<Product> Products { get; private set; }


        private Promotion NewPromotionItem(string description, TypePromotion typePromotion, StatusPromotion statusPromotion)
        {
            return new Promotion
            {
                Description = description,
                StatusPromotion = statusPromotion,
                TypePromotion = typePromotion

            };
        }



    }


    public enum TypePromotion : byte
    {
        [Description("3 for 10")]
        ThreeForTen = 1,

        [Description("Buy 1 take 2")]
        BuyOneTakeTwo = 2,

        [Description("5% discount")]
        DiscountPercent = 3

    }

    public enum StatusPromotion : byte
    {
        [Description("Active")]
        Active = 1,

        [Description("Disabled")]
        Desable = 2
    }
}
