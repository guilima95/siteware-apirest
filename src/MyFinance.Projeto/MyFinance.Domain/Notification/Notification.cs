using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinance.Domain.Notification
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
