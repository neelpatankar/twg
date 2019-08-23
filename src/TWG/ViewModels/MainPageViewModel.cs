using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using TWG.CellModel;
using TWG.Helpers;
using TWG.Models;
using System.Linq;
using TWG.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System;

namespace TWG.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        IPageDialogService pageDialogService;

        public DateTime startDate { get; set; } = DateTime.Now;
        public DateTime endDate { get; set; } = DateTime.Now;

        public string crushID { get; set; }
        public DateTime PropertyMaximumDate = DateTime.Now;
        public ObservableCollection<CellDeginsModel> CellList { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = Appconstant.MainPageTitle;
            this.pageDialogService = pageDialogService;

        }
        public DelegateCommand RefreshCommand => new DelegateCommand(async () =>
        {

            await RunSafe(Griddata());

        });

        public DelegateCommand LogoutCommand => new DelegateCommand(async () =>
        {

            var answer = await pageDialogService.DisplayAlertAsync("Alert", "Would you like to Logout from application", "Yes", "No");
            if (answer)
            {
                await RunSafe(CloseFormAsync());
            }// writes true or false to the console

        });

        async Task Griddata()
        {
            var gridData = new DataSetRequestModel();
            gridData.token = AppConstants.AppToken;
            gridData.deviceName = "POSTMAN";
            gridData.aliasNaming = true;
            gridData.action = "execute";
            gridData.formServiceAction = "R";
            gridData.allowCache = true;

            var actionrequest = new ActionRequest();

            IList<FormAction> formActionsList = new List<FormAction>();
            var form = new FormAction();

            form.command = "SetControlValue";
            form.controlID = "76";
            form.value = startDate.ToString("MM/dd/yyyy");
            formActionsList.Add(form);

            var form1 = new FormAction();
            form1.command = "SetControlValue";
            form1.controlID = "65";
            form1.value = startDate.ToString("MM/dd/yyyy");
           

            var form2 = new FormAction();
            form2.command = "SetControlValue";
            form2.controlID = "27";
            form2.value = crushID;
           

            var form3 = new FormAction();
            form3.command = "DoAction";
            form3.controlID = "15";

            formActionsList.Add(form);
            formActionsList.Add(form1);
            formActionsList.Add(form2);
            formActionsList.Add(form3);

            actionrequest.formActions = formActionsList;

            actionrequest.formOID = "W5540G37A";

            gridData.actionRequest = actionrequest;
            gridData.stackId = AppConstants.stackId;
            gridData.stateId = AppConstants.stateId;
            gridData.rid = AppConstants.Rid;

            var gridResponse = await ApiManager.GetDataSet(gridData);
            CellList = new ObservableCollection<CellDeginsModel>();
            CellList.Clear();
            if (gridResponse.IsSuccessStatusCode)
            {
                var responce = await gridResponse.Content.ReadAsStringAsync();
                var modelserializaton = await Task.Run(() => JsonConvert.DeserializeObject<GridResponceModel>(responce));

                AppConstants.stackId = modelserializaton.stackId;
                AppConstants.stateId = modelserializaton.stateId;
                AppConstants.Rid = modelserializaton.rid;

                IList<CellDeginsModel> cellDeginsList = new List<CellDeginsModel>();
                foreach (var item in modelserializaton.fs_P5540G37_W5540G37A.data.gridData.rowset)
                {
                    var cell = new CellDeginsModel();
                    cell.Name = item.z_ALPH_51.internalValue;
                    cell.Var = item.z_VARCODE_43.internalValue;
                    cell.B = item.z_BLSCD2_53.internalValue;
                    cell.DT = item.z_AWTDOC_56.internalValue;
                    cell.GT = item.z_GRSWTIN_47.internalValue.ToString();
                    cell.NT = item.z_QTRC_46.internalValue.ToString();
                    cell.BX = item.z_55BAVG_48.internalValue.ToString();
                    cell.MOG = item.z_55MOGPCT_49.internalValue.ToString();
                    cellDeginsList.Add(cell);
                }
              
                cellDeginsList?.ForEach((p) => CellList.Add(p));
            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }

        }
        //async Task OpenForm()
        //{
        //    var openform = new OpenFormRequestModel();
        //    openform.token = AppConstants.AppToken;
        //    openform.deviceName = "POSTMAN";
        //    openform.formServiceAction = "R";
        //    openform.allowCache = true;
        //    openform.aliasNaming = true;
        //    openform.version = AppConstants.verison;
        //    openform.formName = "P5540G37_W5540G37A";
        //    openform.action = "open";
        //    openform.formRequest = new FormRequest() { version = AppConstants.verison, formName = "P5540G37_W5540G37A", formServiceAction = "R" };
        //    openform.stackId = 0;
        //    openform.stateId = 0;

        //    var openformobj = await ApiManager.Open(openform);
        //    if (openformobj.IsSuccessStatusCode)
        //    {
        //        var apiresponce = await openformobj.Content.ReadAsStringAsync();
        //        var modelserializaton = await Task.Run(() => JsonConvert.DeserializeObject<OpenFormResponceModel>(apiresponce));
        //        AppConstants.Rid = modelserializaton.rid;
        //        await RunSafe(Griddata());
        //    }
        //}

        async Task LogoutAsync()
        {


            var LogoutResponce = await ApiManager.Logout(new LogoutRequestModel() { token = AppConstants.AppToken });
            if (LogoutResponce.IsSuccessStatusCode)
            {
                AppConstants.AppToken = "";
                AppConstants.stackId = 1;
                AppConstants.stateId = 1;
                AppConstants.Rid = "";
                await _navigationService.GoBackToRootAsync();
            }

        }
        async Task CloseFormAsync()
        {

            var CloseResponce = await ApiManager.AppStack(new AppStackRequestModel()
            {
                action = "close",
                token = AppConstants.AppToken,
                deviceName = "POSTMAN",
                aliasNaming = true,
                allowCache = true,
                rid = AppConstants.Rid,
                stackId = 1,
                stateId = 2
            });
            if (CloseResponce.IsSuccessStatusCode)
            {
                await RunSafe(LogoutAsync());
            }

        }
        public async override void OnAppearing()
        {
            base.OnAppearing();

            await RunSafe(Griddata());
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