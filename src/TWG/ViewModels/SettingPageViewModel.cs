using System;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Pages;

namespace TWG.ViewModels
{
    public class SettingPageViewModel : ViewModelBase
    {
        public SettingPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                  IDeviceService deviceService)
             : base(navigationService, pageDialogService, deviceService)
        {
            
        }

    }
}
