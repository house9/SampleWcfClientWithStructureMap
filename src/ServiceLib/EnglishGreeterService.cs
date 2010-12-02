using System;
using System.ServiceModel;

namespace ServiceLib
{
    public class EnglishGreeterService : IGreeterService
    {
        public string GetGreeting()
        {
            return "Hello";
        }
    }
}
