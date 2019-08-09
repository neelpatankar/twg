using System;
using Prism.Navigation;
using Prism.Services;
using TWG.Resources;
using Xamarin.Forms;

namespace TWG.ViewModels
{
    public class CustNavigationPageViewModel : ViewModelBase
    {
        public CustNavigationPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = AppResources.MainPageTitle;
        }
    }
}

