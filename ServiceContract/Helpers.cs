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
      WriteLine(message, null, ConsoleColor.White);
    }

    public static void WriteLine(string message, ConsoleColor color)
    {
      WriteLine(message, null, color);
    }

    public static void WriteLine(string message, Stopwatch sw, ConsoleColor color)
    {
      Console.ForegroundColor = color;

      if (sw != null && sw.IsRunning)
      {
        message = string.Format("{0} (Seconds elapsed until reached: {1})", message, sw.Elapsed.Seconds);
      }

      Console.WriteLine(message);
    }
  }
}
