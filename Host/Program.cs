using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceContract;

namespace Host
{
  class Program
  {
    static void Main(string[] args)
    {
      Helpers.WriteLine("----- WCF Service Host -----", ConsoleColor.Yellow);
      Helpers.WriteLine("");

      SampleService s = new SampleService();
      s.ShortOneWay("init");
      s.LongOneWay("init");
      s.ShortOneWay("init");

      Helpers.WriteLine("Services are running.");
      Helpers.WriteLine("");

      Helpers.WriteLine("Press 'Enter' to shut down the services.\r\n", ConsoleColor.White);
      Console.ReadLine();
    }
  }
}
