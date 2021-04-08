using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace MagicList.Models
{
    public class ThemeSetting : INotifyPropertyChanged
    {
        private static volatile ThemeSetting instance;
        private static readonly object SyncRoot = new object();
        private ElementTheme appTheme;

        private  ThemeSetting()
        {
            this.appTheme = ApplicationData.Current.LocalSettings.Values.ContainsKey("AppTheme")
                                ? (ElementTheme)ApplicationData.Current.LocalSettings.Values["AppTheme"]
                                : ElementTheme.Default;

        }

        public static  ThemeSetting Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                lock (SyncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ThemeSetting();
                    }
                }

                return instance;
            }
        }

        public ElementTheme AppTheme
        {
            get
            {
                return this.appTheme;
            }

            set
            {
                ApplicationData.Current.LocalSettings.Values["AppTheme"] = (int)value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
