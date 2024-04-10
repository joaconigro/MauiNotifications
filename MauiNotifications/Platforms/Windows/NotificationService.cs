using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace MauiNotifications.Services
{
    public partial class NotificationService
    {
        public partial void ShowNotification(string title, string message)
        {
            string xmlContent = @$"<toast launch=""readMoreArg"">
                                      <visual>
                                        <binding template=""ToastGeneric"">
                                          <text>{title}</text>
                                          <text>{message}</text>
                                        </binding>
                                      </visual>
                                    </toast>
                                 ";
            XmlDocument doc = new();
            doc.LoadXml(xmlContent);

            ToastNotification toast = new(doc);

            // Show the toast notification
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
