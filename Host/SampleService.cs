using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceContract;
using System.Threading;
using System.ServiceModel;

namespace Host
{
  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
  class ConcurrentSampleService : SampleService
  {
    public ConcurrentSampleService()
    {
      color = ConsoleColor.Red;
    }
  }

  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode= InstanceContextMode.Single)]
  class SampleService : ISampleService
  {
    // number of times service call has been made
    int counter = 1;
    static object ilock = new object();
    protected ConsoleColor color = ConsoleColor.Blue;
    

    public void ShortOneWay(string msg)
    {
      Helpers.WriteLine(String.Format("Call {0} - ShortOneWay: {1}", counter++, msg), color);
    }

    public void LongOneWay(string msg)
    {
      lock (ilock)
      {
        int callNum = counter++;
        Helpers.WriteLine(String.Format("Start Call {0} - LongOneWay: {1}", callNum, msg), color);
        Thread.Sleep(5000);
        Helpers.WriteLine(String.Format("  End Call {0} - Long: {1}", callNum, msg), color);
      }
    }

    public void Short(string msg)
    {
      Helpers.WriteLine(String.Format("Call {0} - Short: {1}", counter++, msg), color);
    }

    public void Long(string msg)
    {
      int callNum = counter++;
      Helpers.WriteLine(String.Format("Start Call {0} - Long: {1}", callNum, msg), color);
      Thread.Sleep(5000);
      Helpers.WriteLine(String.Format("  End Call {0} - Long: {1}", callNum, msg), color);
    }

  }
}
