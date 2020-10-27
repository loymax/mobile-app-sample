using System;
using Foundation;
using PushNotification.Service.iOS;

namespace MobileAppSample.iOS.Notifications
{
    [Register("NotificationService")]
    public class NotificationService : BaseNotificationService
    {
        protected override string IosSharedContainerId => "group.com.loymax.sample";

        protected NotificationService(IntPtr handle) : base(handle)
        {
        }
    }
}
