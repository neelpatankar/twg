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
        private string _verison; 

        public string Verison
        {
            get { return _verison; }
            set { SetProperty(ref _verison, value); }
        }

        public SettingPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                  IDeviceService deviceService)
             : base(navigationService, pageDialogService, deviceService)
        {
            this.navigationService = navigationService;
          Verison = AppConstants.Verison;
        }
        public DelegateCommand CloseCommand => new DelegateCommand(async () =>
        {
            AppConstants.Verison =Verison;
            await navigationService.GoBackAsync();
        });

    }
}
