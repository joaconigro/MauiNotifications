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
        public partial async Task ShowNotification(string title, string message)
        {
            var (auth, error) = await UNUserNotificationCenter.Current.RequestAuthorizationAsync(UNAuthorizationOptions.Alert);
            if (!auth || error != null)
            {
                Console.WriteLine(error);
            }

            var settings = await UNUserNotificationCenter.Current.GetNotificationSettingsAsync();
            int timeout = settings.AlertStyle == UNAlertStyle.Alert ? 1 : 5;

            UNMutableNotificationContent content = new()
            {
                Title = title,
                Body = message,
            };

            UNTimeIntervalNotificationTrigger trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(timeout, false);
            UNNotificationRequest request = UNNotificationRequest.FromIdentifier("com.fidelity.atp", content, trigger);

            await UNUserNotificationCenter.Current.AddNotificationRequestAsync(request);
        }
    }
}
