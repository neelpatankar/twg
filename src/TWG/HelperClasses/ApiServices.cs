using System;
using System.Net.Http;
using Fusillade;
using Refit;
using TWG.Interface;

namespace TWG.HelperClasses
{
    public class ApiServices<T> : IApiService<T>
    {
        Func<HttpMessageHandler, T> createClient;

        public ApiServices(string apiBaseAddress)
        {
            createClient = messageHandler =>
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(apiBaseAddress)
                };
                return RestService.For<T>(client);
            };
          
        }
        public T GetToken(Priority prority)
        {
            throw new NotImplementedException();
        }
    }
}
