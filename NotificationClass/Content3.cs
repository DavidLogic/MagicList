using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;

namespace NotificationClass
{
    public class Content3
    {
        public static void PopToast()
        {

            ToastContent content = GenerateToastContent();
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()));
        }
        public static ToastContent GenerateToastContent()
        {
            return new ToastContent()
            {
                Launch = "action=viewEvent&eventId=1983",
                Scenario = ToastScenario.Reminder,

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                {
                    new AdaptiveText()
                    {
                        Text = "已取消提醒"
                    },
                }
                    }
                },

                Actions = new ToastActionsCustom()
                {


                    Buttons =
            {
                new ToastButton("好的",arguments: "okay"),

            }
                }
            };
        }

    
}
}
