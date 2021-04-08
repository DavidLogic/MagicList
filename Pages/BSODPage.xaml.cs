using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MagicList.Models;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MagicList.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BSODPage : Page
    {
        public BSODPage()
            {
                InitializeComponent();
                Window.Current.SetTitleBar(TitleBar);
            }

            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                if (e?.Parameter is string ExceptionMessage)
                {
                    Message.Text = ExceptionMessage;
                }
            }

            private async void Report_Click(object sender, RoutedEventArgs e)
            {
                _ = await Launcher.LaunchUriAsync(new Uri("mailto:2592929967@qq.com?subject=BugReport&body=" + Uri.EscapeDataString(Message.Text)));
            }

            private async void ExportLog_Click(object sender, RoutedEventArgs e)
            {
                FileSavePicker Picker = new FileSavePicker
                {
                    SuggestedFileName = "Export_Error_Log.txt",
                    SuggestedStartLocation = PickerLocationId.Desktop
                };
                Picker.FileTypeChoices.Add(null, new List<string> { ".txt" });

                if (await Picker.PickSaveFileAsync() is StorageFile PickedFile)
                {
                    await LogTracer.ExportLogAsync(PickedFile).ConfigureAwait(false);
                }
            }
    }
    
}
