using System;

namespace ThisApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************************************");

            Bootstrap();
            StaticServiceInvoke();
            StructureMapServiceInvoke();
            StructureMapLocalInvoke();

            Console.WriteLine("************************************************");
            Console.WriteLine("Hit enter to quit");
            Console.ReadLine();
        }

        /// <summary>
        /// bootstrap structure map
        /// </summary>
        static void Bootstrap()
        {
            StructureMap.ObjectFactory.Configure(container =>
            {
                container.For<ThisApplication.IGreeterClientProxy>().Use<GreeterClientProxy>();
                container.For<ServiceLib.IGreeterService>().Use<ServiceLib.EnglishGreeterService>();
                // container.For<ServiceLib.IGreeterService>().Use<ServiceLib.FrenchGreeterService>();
            });
        }

        /// <summary>
        /// call greeter service using static client proxy
        /// </summary>
        static void StaticServiceInvoke()
        {
            using(IGreeterClientProxy client = new GreeterClientProxy())
            {
                Console.WriteLine("  Static Invoke of WCF: " + client.GetGreeting());
            }
        }

        /// <summary>
        /// call greeter service - get client proxy from structure map
        /// </summary>
        static void StructureMapServiceInvoke()
        {
            using(IGreeterClientProxy client = StructureMap.ObjectFactory.GetInstance<ThisApplication.IGreeterClientProxy>())
            {
                Console.WriteLine("  StructureMap Invoke WCF: " + client.GetGreeting());
            }
        }

        
        /// <summary>
        /// init greeter locally via structure map
        /// </summary>
        static void StructureMapLocalInvoke()
        {
            ServiceLib.IGreeterService greeter = StructureMap.ObjectFactory.GetInstance<ServiceLib.IGreeterService>();
            Console.WriteLine("  StructureMap Local Invoke: " + greeter.GetGreeting());
        }
    }
}
