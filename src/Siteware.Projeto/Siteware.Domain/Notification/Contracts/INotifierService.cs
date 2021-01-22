using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Notification.Contracts
{
    public interface INotifierService
    {
        bool ExecuteValidation<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE>
            where TE : class;

        void Notifier(ValidationResult validationResult);
        bool HasNotification();
        void Notifier(string message);
    }
}
