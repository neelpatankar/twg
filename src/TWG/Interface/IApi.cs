using System;
using System.Threading.Tasks;
using Refit;
using TWG.Model;

namespace TWG.Interface
{
    public interface IApi
    {
        [Headers("Content-Type:application/json")]
        [Post("/jderest/tokenrequest")]
        Task<TokenResponse> GetToken([Body]TokenRequestModel tokenRequestModel);
    }
}
