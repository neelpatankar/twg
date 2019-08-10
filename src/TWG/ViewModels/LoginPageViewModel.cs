using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using TWG.Interface;
using TWG.Model;
using TWG.Resources;
using TWG.Services;
using Acr.UserDialogs;
using Xamarin.Forms;
using System.Diagnostics;
using TWG.Helpers;

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

        public DelegateCommand Command => new DelegateCommand(async () => await navigationService.NavigateAsync("SettingPage"));

        public DelegateCommand MainPageCommand => new DelegateCommand(async () =>
        {

            await RunSafe(GetData());

           // await navigationService.NavigateAsync("MainPage");
        });
        async Task GetData()
        {
            var obj = new Model.TokenRequestModel() { deviceName = "POSTMAN", password = "WELCOME1", username = "RDHARA" };
            var makeUpsResponse = await ApiManager.GetToken(obj);

            if (makeUpsResponse.IsSuccessStatusCode)
            {
                var response = await makeUpsResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(() => JsonConvert.DeserializeObject<TokenResponse>(response));
                AppConstants.Token = json.userInfo.token;
                await navigationService.NavigateAsync("MainPage");
            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }
    }
}

