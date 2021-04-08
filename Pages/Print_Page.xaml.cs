using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TaskDataClass.data;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Printing;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MagicList.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Print_Page : Page
    {

        public ObservableCollection<Tasks> tasks= new ObservableCollection<Tasks>() ;
        PrintManager printmgr = PrintManager.GetForCurrentView();
        PrintDocument printDoc = null;
        PrintTask task_ = null;
        public GetPreviewPageEventArgs eventArgs;
        public Print_Page()
        {
            this.InitializeComponent();
           
            printmgr.PrintTaskRequested += Printmgr_PrintTaskRequested;
        }
        private void Printmgr_PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            //从参数的Request属性中获取与PrintTaskRequest的任务关联
            //创建好打印内容和任务后 在调用Complete方法进行打印
            var deferral = args.Request.GetDeferral();
            // 创建打印任务
            task_ = args.Request.CreatePrintTask("MagicList-任务清单", OnPrintTaskSourceRequrested);
            task_.Completed += PrintTask_Completed;
            deferral.Complete();
        }
        private void PrintTask_Completed(PrintTask sender, PrintTaskCompletedEventArgs args)
        {
            //打印完成
        }
        private async void OnPrintTaskSourceRequrested(PrintTaskSourceRequestedArgs args)
        {
            var def = args.GetDeferral();
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    // 设置打印源
                    args.SetSource(printDoc?.DocumentSource);
                });
            def.Complete();
        }
        public  async void Printer_Click()  //调用接口
        {
            if (printDoc != null)
            {
                printDoc.GetPreviewPage -= OnGetPreviewPage;
                printDoc.Paginate -= PrintDic_Paginate;
                printDoc.AddPages -= PrintDic_AddPages;
            }
            this.printDoc = new PrintDocument();
            //订阅预览事件
            printDoc.GetPreviewPage += OnGetPreviewPage;
            //订阅预览时 打印参数发生变化事件 比如文档方向
            printDoc.Paginate += PrintDic_Paginate;
            //添加页面处理事件
            printDoc.AddPages += PrintDic_AddPages;

            // 显示打印对话框
            bool showPrint = await PrintManager.ShowPrintUIAsync();
        }

        //添加打印页面的内容
        private void PrintDic_AddPages(object sender, AddPagesEventArgs e)
        {
            //增加一个页要打印的元素
            printDoc.AddPage(Print_Box);

            //完成对打印页面的增加
            printDoc.AddPagesComplete();
        }
        private void PrintDic_Paginate(object sender, PaginateEventArgs e)
        {
            PrintTaskOptions opt = task_.Options;

            // 设置预览页面的总页数
            printDoc.SetPreviewPageCount(1, PreviewPageCountType.Final);
        }

        private void OnGetPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            // 设置要预览的页面
            eventArgs = e;
            printDoc.SetPreviewPage(e.PageNumber, Print_Box);
            
        }
    }
}
