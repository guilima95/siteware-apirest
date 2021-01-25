using FluentValidation;
using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Validations
{
    public class ProductValidations : AbstractValidator<Product>
    {
        public ProductValidations()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithName("Fill in name the product.");
        }
    }
}