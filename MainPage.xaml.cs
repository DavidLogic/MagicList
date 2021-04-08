using MagicList.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Hosting;
using Microsoft.Graphics.Canvas.Effects;
using Windows.UI;
using System.Collections.ObjectModel;
using MagicList.Models;
using static MagicList.Models.OpenWeatherProxy;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Core;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace MagicList
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<TaskDataClass.data.Tasks> tasks = new ObservableCollection<TaskDataClass.data.Tasks>();

        public MainPage()
        {
            
            this.InitializeComponent();
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true ;
            Window.Current.SetTitleBar(TitleBar);
            BackgroundEffect.Effect.InitializeFrostedGlass(GlassHost);
            Navigation_Frame.Navigate(typeof(Load_Page));
            
            var Current = this;
            if (SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility == AppViewBackButtonVisibility.Collapsed)
            {
                // 显示 TitleBar 左上角的返回按钮
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                // 监听 TitleBar 左上角的返回按钮的点击事件
                SystemNavigationManager.GetForCurrentView().BackRequested += TitleBarDemo_BackRequested;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                SystemNavigationManager.GetForCurrentView().BackRequested -= TitleBarDemo_BackRequested;
            }

        }
        private void TitleBarDemo_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Navigation_Frame.CanGoBack)
                this.Navigation_Frame.GoBack();
        }
        Compositor _compositor = Window.Current.Compositor;
        SpringVector3NaturalMotionAnimation _springAnimation;

        public void CreateOrUpdateSpringAnimation(float finalValue)
        {
            if (_springAnimation == null)
            {
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = new Vector3(finalValue);
        }

        private void CalendarView_Button_Click(object sender, RoutedEventArgs e)
        {

            if (NavigationService.IsPaneOpen == true )
            {
                if (CalendarView_Function.Visibility == Visibility.Visible)
                 {
                CalendarView_Function.Visibility = Visibility.Collapsed ;
                  }
                else
                 {
                CalendarView_Function.Visibility = Visibility.Visible;
                 }
            }
            else
            {
                if (NavigationService.IsPaneOpen == false && CalendarView_Function.Visibility == Visibility.Visible)
                {
                    if (CalendarView_Function.Visibility == Visibility.Visible)
                    {
                        CalendarView_Function.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        CalendarView_Function.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    NavigationService.IsPaneOpen = !NavigationService.IsPaneOpen;
                    if (CalendarView_Function.Visibility == Visibility.Visible)
                    {
                        CalendarView_Function.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        CalendarView_Function.Visibility = Visibility.Visible;
                    }
                }
            }
           
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            sender.ItemsSource = tasks;


        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void NavigationService_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                Navigation_Frame.Navigate(typeof(Setting_Page), null, new DrillInNavigationTransitionInfo());
            }
            else
            {

                switch (args.InvokedItem)
                {
                    case "今天":
                        Navigation_Frame.Navigate(typeof(Today_Page), null, new DrillInNavigationTransitionInfo());
                        break;

                    case "全部计划":
                        Navigation_Frame.Navigate(typeof(My_Plans_Page), null, new DrillInNavigationTransitionInfo());
                        break;
                    case "All Plans":
                        Navigation_Frame.Navigate(typeof(My_Plans_Page), null, new DrillInNavigationTransitionInfo());
                        break;
                    case "已完成计划":
                         Navigation_Frame.Navigate(typeof(Finshed_Page), null, new DrillInNavigationTransitionInfo());
                        break;
                    case "Finished Plans":
                        Navigation_Frame.Navigate(typeof(Finshed_Page), null, new DrillInNavigationTransitionInfo());
                        break;
                    case "进行中":
                        Navigation_Frame.Navigate(typeof(Opening_Page), null, new DrillInNavigationTransitionInfo());
                        break;
                    case "Opening Plans":
                        Navigation_Frame.Navigate(typeof(Opening_Page), null, new DrillInNavigationTransitionInfo());
                        break;
                    case "工作时间表":
                        Navigation_Frame.Navigate(typeof(Schedue_Page), null, new DrillInNavigationTransitionInfo());
                        break;
                }
               
            }
        }

        private void CalendarView_Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation(1.5f);

            (sender as UIElement).StartAnimation(_springAnimation);
        }

        private void CalendarView_Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation (1.0f);

            (sender as UIElement).StartAnimation(_springAnimation);
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var print = new Print_Page();
            print.Printer_Click();
        }

        private void ToggleThemeTeachingTip_ActionButtonClick(Microsoft.UI.Xaml.Controls.TeachingTip sender, object args)
        {
            Navigation_Frame.Navigate(typeof(Today_Page), null, new DrillInNavigationTransitionInfo());
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ToggleThemeTeachingTip.IsOpen = true;
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private async void WeatherFlyOut_Opened(object sender, object e)
        {
            var position = await  LocationManager.GetPosition();

            var lat = position.Coordinate.Latitude;
            var lon = position.Coordinate.Longitude;

            RootObject myWeather =
                await OpenWeatherProxy.GetWeather(
                    lat,
                    lon);
            if (myWeather != null)
            {
                LoadingRing.Visibility = Visibility.Collapsed;
            }
            
            string icon = String.Format("ms-appx:///Assets/{0}.png", myWeather.weather[0].icon);
            ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

            TempTextBlock.Text = "当前温度："+((int)myWeather.main.temp).ToString()+ "℃";
            DescriptionTextBlock.Text = myWeather.weather[0].description;
            LocationTextBlock.Text = myWeather.name;
            AllTempTextBlock.Text = ((float)myWeather.main.temp_min).ToString() + "℃" +"  "+ "-"+ "  " + ((float)myWeather.main.temp_max).ToString()+ "℃"+"\n"+"   "+"气压："+ myWeather.main.pressure.ToString()+"百帕";
            FeelsLikeTextBlock.Text = "体感温度："+myWeather.main.feels_like.ToString()+ "℃";
        }
    }
}
