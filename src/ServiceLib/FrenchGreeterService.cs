using System;
using System.ServiceModel;

namespace ServiceLib
{
    public class FrenchGreeterService : IGreeterService
    {
        public string GetGreeting()
        {
            return "Bonjour";
        }
    }
}
