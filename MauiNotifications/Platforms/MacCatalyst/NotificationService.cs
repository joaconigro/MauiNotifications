using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppKit;
using UserNotifications;

namespace MauiNotifications.Services
{
    public partial class NotificationService
    {
        public partial void ShowNotification(string title, string message)
        {
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge, (b, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine(error);
                }
            });

            UNMutableNotificationContent content = new()
            {
                Title = title,
                Body = message
            };

            UNTimeIntervalNotificationTrigger trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(5, false);
            UNNotificationRequest request = UNNotificationRequest.FromIdentifier("ALERT_REQUEST", content, trigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(request, (error) =>
            {
                if (error != null)
                {
                    Console.WriteLine(error);
                }
            });
        }
    }
}
