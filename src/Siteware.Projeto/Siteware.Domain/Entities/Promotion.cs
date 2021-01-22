using Siteware.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        }

        public string Description { get; set; }
        public TypePromotion TypePromotion { get; set; }
        public StatusPromotion StatusPromotion { get; set; }

        public ICollection<Product> Products { get; set; }

    }


    public enum TypePromotion : byte
    {
        [Description("3 for 10")]
        ThreeForTen = 1,

        [Description("Buy 1 take 2")]
        BuyOneTakeTwo = 2
    }

    public enum StatusPromotion : byte
    {
        [Description("Active")]
        Active = 1,

        [Description("Disabled")]
        Desable = 2
    }
}
