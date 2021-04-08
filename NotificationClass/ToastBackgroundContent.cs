using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace NotificationClass
{
   public class ToastBackgroundContent
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
                        Text = "你的任务已到指定时间！"
                    },
                }
                    }
                },

                Actions = new ToastActionsCustom()
                {
                    Inputs =
            {
                new ToastSelectionBox("snoozeTime")
                {
                    DefaultSelectionBoxItemId = "15",
                    Items =
                    {
                        new ToastSelectionBoxItem("1", "1 minute"),
                        new ToastSelectionBoxItem("15", "15 minutes"),
                        new ToastSelectionBoxItem("60", "1 hour"),
                        new ToastSelectionBoxItem("240", "4 hours"),
                        new ToastSelectionBoxItem("1440", "1 day")
                    }
                }
            },

                    Buttons =
            {
                new ToastButton("完成",arguments: "Finished"),

                new ToastButtonSnooze()
                {
                    SelectionBoxId = "snoozeTime"
                }
            }
                }
            };
        }

    }
}
