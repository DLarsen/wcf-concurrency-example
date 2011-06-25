using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ServiceContract
{
  public class Helpers
  {

    public static void WriteLine(string message)
    {
      WriteLine(message, ConsoleColor.White);
    }

    public static void WriteLine(string message, ConsoleColor color)
    {
      Console.ForegroundColor = color;

      Console.WriteLine("{1:HH:mm:ss} {0}", message, DateTime.Now);
    }
  }
}
