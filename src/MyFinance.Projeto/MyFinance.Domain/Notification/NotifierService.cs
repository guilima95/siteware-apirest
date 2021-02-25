using FluentValidation;
using FluentValidation.Results;
using MyFinance.Domain.Notification.Contracts;

namespace MyFinance.Domain.Notification
{
    public class NotifierService : INotifierService
    {
        private readonly INotifier _notifier;
        public NotifierService(INotifier notifier)
        {
            _notifier = notifier;
        }
        public bool ExecuteValidation<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE>
            where TE : class
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) return true;

            Notifier(validator);

            return false;
        }

        public bool HasNotification()
        {
            return _notifier.HasNotification();
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
            _notifier.Handle(new Notification(message));
        }
    }
}
