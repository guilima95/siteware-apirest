using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Siteware.Domain.Notification;
using Siteware.Domain.Notification.Contracts;
using System;
using System.Linq;

namespace Siteware.API.Controllers.Base
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier notifier;
        public MainController(INotifier notifier)
        {
            this.notifier = notifier;
        }

        protected IActionResult CustomResponse(Object result = null)
        {
            if (ResponseValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            else
            {
                return BadRequest(new
                {
                    errors = notifier.GetNotifications().Select(n => n.Message)
                });
            }
        }

        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifierErrorModelStateInvalid(modelState);
            return CustomResponse();
        }

        protected void NotifierErrorModelStateInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(a => a.Errors);
            foreach (var item in errors)
            {
                var message = item.Exception == null ? item.ErrorMessage : item.Exception.Message;
                NotifierError(message);
            }
        }

        protected void NotifierError(string message)
        {
            notifier.Handle(new Notification(message));
        }

        protected bool ResponseValid() => !notifier.HasNotification();
    }
}
