using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if MACCATALYST
using AppKit;
using UserNotifications;
#endif
namespace MauiNotifications.Services
{
    public class SnackbarService
    {
        public async Task ShowNotification(string message)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;


            //var snackbar = Snackbar.Make(message);
            //await snackbar.Show();

            var toast = Toast.Make(message, duration, fontSize);



            await toast.Show(cancellationTokenSource.Token);
        }

        public void ShowNotificationMac(string title, string message)
        {
#if MACCATALYST
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (auth, error) =>
            {
                if (!auth || error != null)
                {
                    Console.WriteLine(error);
                }
            });

            UNMutableNotificationContent content = new()
            {
                Title = title,
                Body = message,
            };

            UNTimeIntervalNotificationTrigger trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(3, false);
            UNNotificationRequest request = UNNotificationRequest.FromIdentifier("com.fidelity.atp", content, trigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(request, (error) =>
            {
                if (error != null)
                {
                    Console.WriteLine(error);
                }
            });
#endif
        }
    }
}
