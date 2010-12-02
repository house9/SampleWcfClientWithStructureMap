using System;

namespace ThisApplication
{
    // must match ServiceLib.IGreeterService
    public interface IGreeterClientProxy : IDisposable, ServiceLib.IGreeterService
    {
        string GetGreeting();
    }
}
