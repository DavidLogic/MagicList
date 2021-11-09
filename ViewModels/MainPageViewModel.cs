using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicList.Bases;
using Windows.UI.Xaml.Navigation;

namespace MagicList.ViewModels
{
    public class MainPageViewModel :ViewModelBase
    {
        private bool isSettingInvoked;
        public bool IsSettingInvoked
        {
        
            get
            { 
                return isSettingInvoked; 
            }
            set 
            { 
                isSettingInvoked = value;
            }
        }
    }
}
