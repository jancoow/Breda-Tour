using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Breda_Tour
{
    class Notification
    {
        public Notification(string title, string message)
        {
            sendNote(standardNotification(title, message));
        }

        public string standardNotification(string title, string message)
        {
            return $@"
            <toast activationType='foreground' launch='args'>
                <visual>
                    <binding template='ToastGeneric'>
                        <text>{ title }</text>
                        <text>{ message }</text>
                    </binding>
                </visual>
            </toast>";

        }

        public void sendNote(string content)
        {

            // Notificatie moet in een XML formaat aangeleverd worden
            XmlDocument doc = new XmlDocument();
            // Onze XAML code erin zetten
            doc.LoadXml(content);
            // Inladen in een toast notificatie (Standaard in Windows 10)
            ToastNotification notification = new ToastNotification(doc);
            // Toast Manager aanmaken, oproepen en bewaren
            ToastNotifier notifier = ToastNotificationManager.CreateToastNotifier();
            // Notificatie aanleveren aan manager, de manager toont vervolgens de notificatie
            notifier.Show(notification);
        }
    }
}
