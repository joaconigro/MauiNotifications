using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNotifications.Services
{
    public class SnackbarService
    {
        public async Task ShowNotification( string message)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;


            //var snackbar = Snackbar.Make(message);
            //await snackbar.Show();

            var toast = Toast.Make(message, duration, fontSize);



            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
