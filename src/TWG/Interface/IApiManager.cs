using System;
using System.Net.Http;
using System.Threading.Tasks;
using TWG.Model;

namespace TWG. Interface
{

    public interface IApiManager
    {
        Task<HttpResponseMessage> GetToken(TokenRequestModel tokenRequestModel );
    }
}
