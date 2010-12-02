using System;
using System.ServiceModel;

namespace ThisApplication
{
    public class GreeterClientProxy : 
        DisposableClientBase<ServiceLib.IGreeterService>, 
        IGreeterClientProxy
    {
        public GreeterClientProxy() : base()
        { 
        }

        public string GetGreeting()
        {
            return base.Channel.GetGreeting();
        }
    }
}
