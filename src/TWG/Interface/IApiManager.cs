using System.Net.Http;
using System.Threading.Tasks;
using TWG.Models;
using TWG.ViewModels;

namespace TWG.Interface
{

    public interface IApiManager
    {
        Task<HttpResponseMessage> GetToken(TokenRequestModel tokenRequestModel );

        Task<HttpResponseMessage> Open(OpenFormRequestModel openRequestModel);
    
        Task<HttpResponseMessage> GetDataSet(DataSetRequestModel dataSetRequestModel);
  
        Task<HttpResponseMessage> AppStack(AppStackRequestModel appStackRequestModel);
        
        Task<HttpResponseMessage> Logout(LogoutRequestModel logoutRequestModel);
    }
}
