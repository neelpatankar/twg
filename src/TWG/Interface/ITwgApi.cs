using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using TWG.Models;
using TWG.ViewModels;

namespace TWG.Interface
{
    public interface ITwgApi
    {
        [Headers("Content-Type:application/json")]
        [Post("/jderest/tokenrequest")]
        Task<HttpResponseMessage> GetToken([Body]TokenRequestModel tokenRequestModel);

        [Headers("Content-Type:application/json")]
        [Post("/jderest/appstack")]
        Task<HttpResponseMessage> Open([Body]OpenFormRequestModel openRequestModel);

        [Headers("Content-Type:application/json")]
        [Post("/jderest/appstack")]
        Task<HttpResponseMessage> GetDataSet([Body]DataSetRequestModel fbformResponceModel);

        [Headers("Content-Type:application/json")]
        [Post("/jderest/appstack")]
        Task<HttpResponseMessage> AppStack([Body]AppStackRequestModel appStackRequestModel);

        [Headers("Content-Type:application/json")]
        [Post("/jderest/tokenrequest/logout")]
        Task<HttpResponseMessage> Logout([Body]LogoutRequestModel logoutRequestModel);
    }
}
