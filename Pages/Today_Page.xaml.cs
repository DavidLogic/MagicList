using TaskDataClass.data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using Windows.Storage;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using MagicList.Models;
using Windows.UI.Notifications;
using System.Xml;
using Windows.Data.Xml.Dom;



// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MagicList.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Today_Page : Page
    {  
        public Print_Page print_Page;
        public ObservableCollection<Tasks> task;
        public  string clickedItem;
       
        public bool Printer_Checked = false;
       public string titelcontent;
        public Today_Page()
        {
            
            this.InitializeComponent();
            Today_Header.Text = DateTime.Now.ToLongDateString().ToString();
            task = new  ObservableCollection<Tasks>();
            Today_Header.Text = DateTime.Now.ToLongDateString().ToString();
            lunar_Header.Text = ChineseDateTime.GetChineseDateTime(DateTime.Now);
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
        private void Add_Task_Click(object sender, RoutedEventArgs e)
        {
            Creat_New_Task_View.Visibility = Visibility.Visible;
        }
        
        private async void openFileButton_Click(object sender, RoutedEventArgs e)
        {
           Windows.Storage.Pickers.FileOpenPicker open =  new Windows.Storage.Pickers.FileOpenPicker();
     
           open.SuggestedStartLocation =Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                
           open.FileTypeFilter.Add(".txt");

            Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

            if (file != null)
           {
                using (Windows.Storage.Streams.IRandomAccessStream randAccStream =  await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                 
                {
                    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                    string text = await FileIO.ReadTextAsync(file);
                    Creat_New_Task_Box.Text = text;
              }
            }

        }

        public void Add_Task_PointerEntered(object sender, PointerRoutedEventArgs e)
        { 
                CreateOrUpdateSpringAnimation(1.5f);

                (sender as UIElement).StartAnimation(_springAnimation);     
        }

        public void Add_Task_PointerExited(object sender, PointerRoutedEventArgs e)
        {
                CreateOrUpdateSpringAnimation(1.0f);

                (sender as UIElement).StartAnimation(_springAnimation);
            
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {

            Creat_New_Task_View.Visibility = Visibility.Collapsed;
            task.Add(new Tasks { Importance_value = Importance_Level.Value, task_Content = Creat_New_Task_Box.Text, task_Date = Date_Picker.Date.ToString(), task_Time = Time_Picker.Time.ToString() , task_Title = Creat_New_Task_Title_Box.Text , IsTaskFinished = false } );
            Creat_New_Task_Title_Box.Text = string.Empty;
            Creat_New_Task_Box.Text = string.Empty;
            NotificationClass.Content2.PopToast();
            GetDataAsync();
        }

        private void Give_up_Button_Click(object sender, RoutedEventArgs e)
        {
            Creat_New_Task_View.Visibility = Visibility.Collapsed;
            Creat_New_Task_Title_Box.Text = string.Empty;
            Creat_New_Task_Box.Text = string.Empty;
        }

        private void Print_List_Click(object sender, RoutedEventArgs e)
        {
            if (Printer_Checked ==false)
            {
                print_Page = new Print_Page();
            }
            
            print_Page.Printer_Click();
            Printer_Checked = true;
        }

        private void Task_Button_Click(object sender, RoutedEventArgs e)
        {
            DetailPane.IsPaneOpen = !DetailPane.IsPaneOpen;
        }


        private void Delelte_Button_Click(object sender, RoutedEventArgs e)
        {
            var a = Achieve_Button.Parent;
            if (Task_List.SelectedIndex >= 0)
            {
                task.RemoveAt(Task_List.SelectedIndex);
            }
        }

        private void Achieved_Button_Click(object sender, RoutedEventArgs e)
        {

            if(Task_List.SelectedIndex >=0)
            {
                task.RemoveAt(Task_List.SelectedIndex);
            }
           
           
        }

        private void Notification_btn_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush colorBrush = (SolidColorBrush)notifi.Foreground;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(100, 255, 190, 0));  //Yellow Brush
            SolidColorBrush solidColor = new SolidColorBrush(Windows.UI.Color.FromArgb(100, 0, 0, 0));  //Black Brush
            NotificationClass.Content2.PopToast();
                
            // if(colorBrush != solidColor                                                                                
        }

        private void Give_up_Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var expressionAnim = _compositor.CreateExpressionAnimation();
            expressionAnim.Expression = "Vector3(1/scaleElement.Scale.X, 1/scaleElement.Scale.Y, 1)";
            expressionAnim.Target = "Scale";
            expressionAnim.SetExpressionReferenceParameter("scaleElement", Give_up_Button);
            Create_Button.StartAnimation(expressionAnim);
            CreateOrUpdateSpringAnimation(1.2f);
            (sender as UIElement).StartAnimation(_springAnimation);
        }

        private void Create_Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var expressionAnim = _compositor.CreateExpressionAnimation();
            expressionAnim.Expression = "Vector3(1/scaleElement.Scale.X, 1/scaleElement.Scale.Y, 1)";
            expressionAnim.Target = "Scale";
            expressionAnim.SetExpressionReferenceParameter("scaleElement", Create_Button);
            Give_up_Button.StartAnimation(expressionAnim);
            CreateOrUpdateSpringAnimation(1.2f);

            (sender as UIElement).StartAnimation(_springAnimation);
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
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Mountains.jpg", UriKind.Absolute));
            this.Background = imageBrush;
          
        }

        private void Task_List_ItemClick(object sender, ItemClickEventArgs e)
        {
            DetailPane.IsPaneOpen = !DetailPane.IsPaneOpen;
            clickedItem = e.ClickedItem.ToString();
            if (Task_List.SelectedIndex >=0)
            {
             titeldetail.Text = task.ElementAt(Task_List.SelectedIndex).task_Title;
            taskdate.Text = task.ElementAt(Task_List.SelectedIndex).task_Date;
            tasktime.Content = "将在" + task.ElementAt(Task_List.SelectedIndex).task_Time+ "时提醒您";
            taskvalue.Value = task.ElementAt(Task_List.SelectedIndex).Importance_value;
                taskdetail.Text = task.ElementAt(Task_List.SelectedIndex).task_Content;
            }

        }
      
       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/NewYearEve.jpg", UriKind.Absolute));
            this.Background = imageBrush;
        }



        private void Achieve_Button_Click_1(object sender, RoutedEventArgs e)
        {
           var a =  Achieve_Button.Parent;
            if (Task_List.SelectedIndex >= 0)
            {
                task.RemoveAt(Task_List.SelectedIndex);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
             GetDataAsync();
            ToggleThemeTeachingTip1.IsOpen = true;
        }
        public async void GetDataAsync()
        {



                for (int i = 1; i <= Task_List.SelectedIndex; i++)

                {

                    var titel = task.ElementAt(i);
                    titelcontent = titel.task_Title; 
                    


                }
        }

        private void Tasktime_Click(object sender, RoutedEventArgs e)
        {
            NotificationClass.Content3.PopToast();
        }
    }
}
