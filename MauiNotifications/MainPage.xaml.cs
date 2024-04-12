using MauiNotifications.Services;

namespace MauiNotifications
{
    public partial class MainPage : ContentPage
    {
        //private readonly NotificationService _notificationService = new();
        private readonly SnackbarService _notificationService = new();
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
#if WINDOWS
            _notificationService.ShowNotification("this is a test message");

#elif MACCATALYST
            _notificationService.ShowNotificationMac("ATP", "this is a test message");

#endif
        }
    }

}
