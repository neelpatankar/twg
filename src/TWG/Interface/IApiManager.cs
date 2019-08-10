using System;
using System.Net.Http;
using System.Threading.Tasks;
using TWG.Model;
using TWG.Models;

namespace TWG. Interface
{

    public interface IApiManager
    {
        Task<HttpResponseMessage> GetToken(TokenRequestModel tokenRequestModel );

        Task<HttpResponseMessage> Open(OpenRequestModel openRequestModel);
    
        Task<HttpResponseMessage> Fbform(FbformResponceModel fbformResponceModel);
  
        Task<HttpResponseMessage> AppStack(AppStackRequestModel appStackRequestModel);
        
        Task<HttpResponseMessage> Logout(LogoutRequestModel logoutRequestModel);
    }
}
