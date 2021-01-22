﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Notification.Contracts
{
    public interface INotifier
    {
        List<Domain.Notification.Notification> GetNotifications();
        void Handle(Notification notification);
        bool HasNotification();

    }
}
