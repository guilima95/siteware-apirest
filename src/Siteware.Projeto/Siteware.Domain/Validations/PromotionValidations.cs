using FluentValidation;
using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Validations
{
    public class PromotionValidations : AbstractValidator<Promotion>
    {
        public PromotionValidations()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Fill in description the promotion.");
            RuleFor(x => x.StatusPromotion)
                .NotEmpty()
                .WithName("Fill in status the promotion.");
        }
    }
}