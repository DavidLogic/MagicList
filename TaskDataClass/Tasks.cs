using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDataClass.data
{
    public class Tasks
    {
        public string task_Title { get; set; }
        public string task_Content { get; set; }
        public double Importance_value { get; set; }
        public string task_Date { get; set; }
        public string task_Time { get; set; }
        public bool   IsTaskFinished { get; set; }

        public  void showtoast()
        {
            if (DateTime.Now.ToShortTimeString()==task_Time && DateTime.Now.ToShortDateString() ==task_Date)
            {
                NotificationClass.ToastBackgroundContent.PopToast();
            }
        }
    }
}
