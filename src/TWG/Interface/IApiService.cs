using System;
using Fusillade;

namespace TWG.Interface
{
    public interface IApiService<T>
    {
        T GetApi(Priority priority);
    }
}
