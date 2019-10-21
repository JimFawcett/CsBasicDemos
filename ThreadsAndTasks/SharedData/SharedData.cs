///////////////////////////////////////////////////////////////////
// SharedData.cs - Demonstrate sharing with lock                 //
//                                                               //
// Jim Fawcett, CSE686 - Internet Programming, Spring 2014       //
///////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SharedData
{
  class SharedData
  {
    static object locker = new object();
    static void Main(string[] args)
    {
      Console.Write("\n  Sharing Data");
      Console.Write("\n ==============\n");

      string shared = "";  // captured by lambda's closure

      ParameterizedThreadStart pts = (myNumber) =>
      {
        for (int i = 0; i < 5; ++i)
        {
          lock (locker)                  // serialize access to
          {                              // shared string
            shared += myNumber.ToString();
          }
          Thread.Sleep((int)myNumber);   // cause thread actions
        }                                // to interleave randomly
      };
      new Thread(pts).Start(1);
      new Thread(pts).Start(2);
      new Thread(pts).Start(3);

      Console.Write("\n  Press Key to continue: ");
      Console.ReadKey();

      Console.Write("\n  shared = {0}", shared);
      Console.Write("\n\n");
    }
  }
}
