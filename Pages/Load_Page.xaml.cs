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
using MagicList;
using Windows.UI.Xaml.Media.Animation;


// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MagicList.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Load_Page : Page
    {
        public Load_Page()
        {
         
           
            this.InitializeComponent();   
        }

        private void NewTask_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Today_Page), null, new DrillInNavigationTransitionInfo());
        }
    }

}
