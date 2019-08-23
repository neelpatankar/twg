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

       
        public string username { get; set; }
        public string password { get; set; }

        private INavigationService navigationService;
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService, IDevice device)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = Appconstant.MainPageTitle;
            this.navigationService = navigationService;
            this.device = device;
            username = AppConstants.Username;
            password = AppConstants.Password;
        }

        public DelegateCommand Command => new DelegateCommand(async () => await navigationService.NavigateAsync("SettingPage"));


        public DelegateCommand MainPageCommand => new DelegateCommand(async () =>
        {
            await RunSafe(GetData());

        });
        async Task OpenForm()
        {
            var openform = new OpenFormRequestModel();
            openform.token = AppConstants.AppToken;
            openform.deviceName = "POSTMAN";
            openform.formServiceAction = "R";
            openform.allowCache = true;
            openform.aliasNaming = true;
            openform.version = AppConstants.Verison;
            openform.formName = "P5540G37_W5540G37A";
            openform.action = "open";
            openform.formRequest = new FormRequest() { version = AppConstants.Verison, formName = "P5540G37_W5540G37A", formServiceAction = "R" };
            openform.stackId = 0;
            openform.stateId = 0;

            var openformobj = await ApiManager.Open(openform);
            if (openformobj.IsSuccessStatusCode)
            {
                var apiresponce = await openformobj.Content.ReadAsStringAsync();
                var modelserializaton = await Task.Run(() => JsonConvert.DeserializeObject<OpenFormResponceModel>(apiresponce));
                AppConstants.Rid = modelserializaton.rid;
                await navigationService.NavigateAsync("MainPage");
            }
        }
        async Task GetData()
        {

            AppConstants.Username = username;
            AppConstants.Password = password;
            var obj = new TokenRequestModel() { deviceName = "POSTMAN", password = this.password, username = this.username };
            var TokenResponse = await ApiManager.GetToken(obj);

            if (TokenResponse.IsSuccessStatusCode)
            {
                var response = await TokenResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(() => JsonConvert.DeserializeObject<TokenResponse>(response));
                AppConstants.AppToken = json.userInfo.token;
                await RunSafe(OpenForm());

            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }
    }
}

