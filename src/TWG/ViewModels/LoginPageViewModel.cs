using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using TWG.Interface;
using TWG.Resources;
using TWG.Helpers;
using TWG.Models;

namespace TWG.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public bool Visible { get; set; } = false;
        private IDevice device;
        private INavigationService navigationService;
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService,IDevice device)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = AppResources.MainPageTitle;
            this.navigationService = navigationService;
            this.device = device;
        }

        public DelegateCommand Command => new DelegateCommand(async () => await navigationService.NavigateAsync("SettingPage"));

        public DelegateCommand MainPageCommand => new DelegateCommand(async () =>
        {

            await RunSafe(GetData());

           // await navigationService.NavigateAsync("MainPage");
        });
        async Task GetData()
        {
            var obj = new TokenRequestModel() { deviceName = "POSTMAN", password = "WELCOME1", username = "RDHARA" };
            var TokenResponse = await ApiManager.GetToken(obj);

            if (TokenResponse.IsSuccessStatusCode)
            {
                var response = await TokenResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(() => JsonConvert.DeserializeObject<TokenResponse>(response));
                AppConstants.AppToken = json.userInfo.token;

                var openform = new OpenFormRequestModel() ;
                openform.token = AppConstants.AppToken;
                openform.deviceName = "POSTMAN";
                openform.formServiceAction = "R";
                openform.allowCache = true;
                openform.aliasNaming = true;
                openform.version = "TWG0001";
                openform.formName = "P5540G37_W5540G37A";
                openform.action = "open";
                openform.formRequest = new FormRequest() { version = "TWG0001", formName = "P5540G37_W5540G37A", formServiceAction = "R" };
                openform.stackId = 0;
                openform.stateId = 0;

                var makeUpsResponse = await ApiManager.Open(openform);
                if (makeUpsResponse.IsSuccessStatusCode)
                {
                    var apiresponce = await makeUpsResponse.Content.ReadAsStringAsync();
                    var modelserializaton = await Task.Run(() => JsonConvert.DeserializeObject<OpenFormResponceModel>(apiresponce));
                    AppConstants.Rid = modelserializaton.rid;
                    await navigationService.NavigateAsync("MainPage");
                }

               
            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }
    }
}

