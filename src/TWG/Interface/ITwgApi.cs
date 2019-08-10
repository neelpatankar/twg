using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using TWG.Model;
using TWG.Models;

namespace TWG.Interface
{
    public interface ITwgApi
    {
        [Headers("Content-Type:application/json")]
        [Post("/jderest/tokenrequest")]
        Task<HttpResponseMessage> GetToken([Body]TokenRequestModel tokenRequestModel);

        [Headers("Content-Type:application/json")]
        [Post("/jderest/appstack")]
        Task<HttpResponseMessage> Open([Body]OpenRequestModel openRequestModel);

        [Headers("Content-Type:application/json")]
        [Post("/jderest/appstack")]
        Task<HttpResponseMessage> Fbform([Body]FbformResponceModel fbformResponceModel);

        [Headers("Content-Type:application/json")]
        [Post("/jderest/appstack")]
        Task<HttpResponseMessage> AppStack([Body]AppStackRequestModel appStackRequestModel);

        [Headers("Content-Type:application/json")]
        [Post("/jderest/tokenrequest/logout")]
        Task<HttpResponseMessage> Logout([Body]LogoutRequestModel logoutRequestModel);
    }
}
