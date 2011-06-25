using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceContract;
using System.ServiceModel;

namespace Host
{
  class Program
  {
    static void Main(string[] args)
    {
      Helpers.WriteLine("----- WCF Service Host -----", ConsoleColor.Yellow);
      Helpers.WriteLine("");

      ServiceHost singleHost = new ServiceHost(typeof(SampleService));
      ServiceHost concurrentHost = new ServiceHost(typeof(ConcurrentSampleService));
      ServiceManager.OpenHost(singleHost, "-single");
      ServiceManager.OpenHost(concurrentHost, "-concurrent");
      Helpers.WriteLine("Services are running.");

      Helpers.WriteLine("");

      Helpers.WriteLine("Press 'Enter' to shut down the services.\r\n", ConsoleColor.White);
      Console.ReadLine();
    }
  }
}
