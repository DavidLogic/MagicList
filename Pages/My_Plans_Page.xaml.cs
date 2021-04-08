using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TaskDataClass.data;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MagicList.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class My_Plans_Page : Page
    {
        public Today_Page taskgetter = new Today_Page();
        public ObservableCollection<Tasks> alltasks;
        public My_Plans_Page()
        {
            this.InitializeComponent();
           alltasks = new ObservableCollection<Tasks>();
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Book.jpg", UriKind.Absolute));
            this.Background = imageBrush;
            var thetask = taskgetter.task;
            alltasks = thetask;
            

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
    }
}
