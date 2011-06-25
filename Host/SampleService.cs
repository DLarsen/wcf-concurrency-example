using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceContract;
using System.Threading;

namespace Host
{
  class SampleService : ISampleService
  {
    // number of times service call has been made
    static int counter = 1;

    

    public void ShortOneWay(string msg)
    {
      Console.WriteLine("Call {0} - ShortOneWay: {1}", counter++, msg);
    }

    public void LongOneWay(string msg)
    {
      int callNum = counter++;
      Console.WriteLine("Start Call {0} - LongOneWay: {1}", callNum, msg);
      Thread.Sleep(5000);
      Console.WriteLine("  End Call {0} - Long: {1}", callNum, msg);
    }

    public void Short(string msg)
    {
      Console.WriteLine("Call {0} - Short: {1}", counter++, msg);
    }

    public void Long(string msg)
    {
      int callNum = counter++;
      Console.WriteLine("Start Call {0} - Long: {1}", callNum, msg);
      Thread.Sleep(5000);
      Console.WriteLine("  End Call {0} - Long: {1}", callNum, msg);
    }

  }
}
