using System;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Pages;
using TWG.Helpers;

namespace TWG.ViewModels
{
    public class SettingPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public string AppUrl
        {
            get
            {
                return AppConstants.ApiUrl;
            }
            set
            {
                AppConstants.ApiUrl = value;
            }
        }

        public string version
        {
            get
            {
                return AppConstants.verison;
            }
            set
            {
                AppConstants.verison = value;
            }
        }
        public SettingPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                  IDeviceService deviceService)
             : base(navigationService, pageDialogService, deviceService)
        {
            this.navigationService = navigationService;
        }
        public DelegateCommand CloseCommand => new DelegateCommand(async () =>
        {
            await navigationService.GoBackAsync();
        });

    }
}
