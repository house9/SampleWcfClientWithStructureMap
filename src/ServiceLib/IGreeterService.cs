using System;
using System.ServiceModel;

namespace ServiceLib
{
    [ServiceContract]
    public interface IGreeterService
    {
        [OperationContract]
        string GetGreeting();
    }
}
