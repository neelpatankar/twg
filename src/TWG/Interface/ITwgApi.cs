using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using TWG.Model;

namespace TWG.Interface
{
    public interface ITwgApi
    {
        [Headers("Content-Type:application/json")]
        [Post("/jderest/tokenrequest")]
        Task<HttpResponseMessage> GetToken([Body]TokenRequestModel tokenRequestModel);
    }
}
