using System;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using TWG.Resources;
using Xamarin.Forms;

namespace TWG.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public bool Visible { get; set; } = false;

        private INavigationService navigationService;
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = AppResources.MainPageTitle;
            this.navigationService = navigationService;
        }

        public DelegateCommand Command => new DelegateCommand(async() => {
         await   navigationService.NavigateAsync("SettingPage");
        });
        public DelegateCommand MainPageCommand => new DelegateCommand(async () =>
        {
            await navigationService.NavigateAsync("MainPage");
        });
       
    }
}

