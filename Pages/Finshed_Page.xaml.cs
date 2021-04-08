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
using BackgroundEffect;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;
using TaskDataClass.data;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MagicList.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>  
    /// 

    public sealed partial class Finshed_Page : Page
    {
        public ObservableCollection<Tasks> task;
        public Finshed_Page()
        {
            this.InitializeComponent();
            task = new ObservableCollection<Tasks>();
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Book.jpg", UriKind.Absolute));
            this.Background = imageBrush;
        }

        private void Add_Task_PointerEntered(object sender, PointerRoutedEventArgs e)
        {

        }

        private void Add_Task_PointerExited(object sender, PointerRoutedEventArgs e)
        {

        }

        private void Print_List_Click(object sender, RoutedEventArgs e)
        {
            var print = new Print_Page();
            print.Printer_Click();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Book.jpg", UriKind.Absolute));
            this.Background = imageBrush;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Mountain.jpg", UriKind.Absolute));
            this.Background = imageBrush;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/NewYearEve.jpg", UriKind.Absolute));
            this.Background = imageBrush;
        }

        private void Delelte_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Achieve_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Notification_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
    