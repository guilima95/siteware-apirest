using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Services.Base.Contracts
{
    public interface IService
    {
        void Notifier(ValidationResult validationResult);
        void Notifier(string message);
        bool HasNotification();

        bool ExecuteValitation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : class;
    }
}
