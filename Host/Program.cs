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

      ServiceHost hostDefault = new ServiceHost(typeof(SampleService));
      ServiceManager.OpenHost(hostDefault);
      Helpers.WriteLine("Services are running.");
      
      var proxy = ServiceManager.CreateChannel(hostDefault);
      
      // call the local proxy
      var msg = "Called from Host";
      proxy.ShortOneWay(msg);
      proxy.LongOneWay(msg);
      proxy.ShortOneWay(msg);
      proxy.LongOneWay(msg);

      proxy.Short(msg);
      proxy.Long(msg);
      proxy.Short(msg);
      proxy.Long(msg);
      
      Helpers.WriteLine("");

      Helpers.WriteLine("Press 'Enter' to shut down the services.\r\n", ConsoleColor.White);
      Console.ReadLine();
    }
  }
}
