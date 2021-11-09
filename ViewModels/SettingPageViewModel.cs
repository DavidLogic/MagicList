using MagicList.Bases;
using MagicList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace MagicList.ViewModels
{
   public class SettingPageViewModel : ViewModelBase
    {
        private ElementThemeExtended _elementTheme = ThemeSelector.Theme;
        private string _versionDescription;
        private ICommand _switchThemeCommand;

        public ElementThemeExtended ElementThemeExtended
        {
            get
            {
                return _elementTheme;
            }

            set
            {
                if (_elementTheme != value)
                {
                    _elementTheme = value;
                    RaisePropertyChanged(nameof(VersionDescription));
                }
            }
        }
        public string VersionDescription
        {
            get
            {
                return _versionDescription;
            }

            set
            {
                if (_versionDescription != value)
                {
                    _versionDescription = value;
                    RaisePropertyChanged(nameof(VersionDescription));
                }
            }
        }
        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementThemeExtended>(
                        async (param) =>
                        {
                            await ThemeSelector.SetThemeAsync(param);
                        });
                }

                return _switchThemeCommand;
            }
        }
    }
}
