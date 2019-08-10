using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Fusillade;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Polly;
using Refit;
using TWG.Helpers;
using TWG.Interface;
using TWG.Model;
using Xamarin.Essentials;

namespace TWG.Services
{
    public class ApiManager : IApiManager
    {
        IUserDialogs _userDialogs = UserDialogs.Instance;
        IConnectivity _connectivity = CrossConnectivity.Current;
        IApiService<ITwgApi> iApi;
        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }
        Dictionary<int, CancellationTokenSource> runningTasks = new Dictionary<int, CancellationTokenSource>();
        Dictionary<string, Task<HttpResponseMessage>> taskContainer = new Dictionary<string, Task<HttpResponseMessage>>();

        public ApiManager(IApiService<ITwgApi> _iApi)
        {
            iApi = _iApi;
            IsConnected = _connectivity.IsConnected;
            _connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        void OnConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            IsConnected = e.IsConnected;

            if (!e.IsConnected)
            {
                // Cancel All Running Task
                var items = runningTasks.ToList();
                foreach (var item in items)
                {
                    item.Value.Cancel();
                    runningTasks.Remove(item.Key);
                }
            }
        }
     

        protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task)
            where TData : HttpResponseMessage,
            new()
        {
            var data = new TData();

            if (!IsConnected)
            {
                var strngResponse = "There's not a network connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(strngResponse);

                _userDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            IsReachable = await _connectivity.IsRemoteReachable(AppConstants.ApiUrl);

            if (!IsReachable)
            {
                var strngResponse = "There's not an internet connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(strngResponse);

                _userDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            data = await Policy
            .Handle<WebException>()
            .Or<ApiException>()
            .Or<TaskCanceledException>()
            .WaitAndRetryAsync
            (
                retryCount: 1,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
            )
            .ExecuteAsync(async () =>
            {
                var result = await task;

                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //Logout the user 
                }
                runningTasks.Remove(task.Id);

                return result;
            });

            return data;
        }

        public async Task<HttpResponseMessage> GetToken(TokenRequestModel tokenRequestModel)
        {
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync<HttpResponseMessage>(iApi.GetApi(Priority.UserInitiated).GetToken(tokenRequestModel));
            runningTasks.Add(task.Id, cts);

            return await task;
        }
    }

}
