using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using NotificationClass;
using TaskDataClass.data;

namespace NotificationToast
{
    public sealed class ToastBackgroundTask:IBackgroundTask
    {
         public void Run(IBackgroundTaskInstance taskInstance)
        {
            
            var defferral = taskInstance.GetDeferral();
            var a = new Tasks();
            a.showtoast();
            defferral.Complete();
        }

    }
}
