using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using TWG.Models;
using TWG.Resources;
using Xamarin.Forms;

namespace TWG.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        IPageDialogService pageDialogService;
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = AppResources.MainPageTitle;
            this.pageDialogService = pageDialogService;
        }

        public DelegateCommand LogoutCommand => new DelegateCommand(async () => {
          
                var answer = await pageDialogService.DisplayAlertAsync("Question?", "Would you like to play a game", "Yes", "No");
                Debug.WriteLine("Answer: " + answer); // writes true or false to the console
          
        });

        async Task GetGridData() {

            var makeUpsResponse = await ApiManager.GetDataSet(new Models.DataSetRequestModel());
            if (makeUpsResponse.IsSuccessStatusCode)
            {
                var apiresponce = await makeUpsResponse.Content.ReadAsStringAsync();
                var modelserializaton = await Task.Run(() => JsonConvert.DeserializeObject<OpenFormResponceModel>(apiresponce));
          
            }

        }
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            switch (parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    // TODO: Handle any tasks that should occur only when navigated back to
                    break;
                case NavigationMode.New:
                    // TODO: Handle any tasks that should occur only when navigated to for the first time
                    break;
            }

            // TODO: Handle any tasks that should be done every time OnNavigatedTo is triggered
        }
    }
}