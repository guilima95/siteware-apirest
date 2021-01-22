using FluentValidation;
using FluentValidation.Results;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Services.Base
{
    public class Service : IService
    {
        private readonly INotifier notifier;
        public Service(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public void Notifier(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notifier(item.ErrorMessage);
            }
        }

        public void Notifier(string message)
        {
            notifier.Handle(new Notification.Notification(message));
        }

        public bool HasNotification()
        {
            return notifier.HasNotification();
        }

        public bool ExecuteValitation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) return true;

            Notifier(validator);

            return false;
        }
    }
}
