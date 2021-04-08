using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Core;
using muxc = Microsoft.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MagicList.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Setting_Page : Page
    {
        public Setting_Page()
        {
            this.InitializeComponent();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (RestartTip== null) return;
            if ((sender as ComboBox).SelectedIndex == 0)
            {
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["CurrentLanguage"] = "zh-cn";
            }
            else if ((sender as ComboBox).SelectedIndex == 1)
            {
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["CurrentLanguage"] = "en-us";
            }

           
             RestartTip.IsOpen = true;



        }

        private async void restart_button_Click(object sender, RoutedEventArgs e)
        {
            await  CoreApplication.RequestRestartAsync(string.Empty);
        }

        
    }
}
