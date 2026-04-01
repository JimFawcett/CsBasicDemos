///////////////////////////////////////////////////////////////////
// ConcurrentThreads.cs - Demonstrate concurrency                //
//                                                               //
// Jim Fawcett, CSE686 - Internet Programming, Spring 2014       //
///////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace concurrentThreads
{
  class ConcurrentThreads
  {
    static void Main(string[] args)
    {
      Console.Write("\n  Demo thread parameters");
      Console.Write("\n ========================\n");

      double pi = 3.1415927;  // captured by lambda's closure

      ParameterizedThreadStart pts = (myNumber) =>
      {
        Console.Write("\n  Hello from thread {0}. I see {1}", myNumber, pi);
      };
      new Thread(pts).Start(1);
      new Thread(pts).Start(2);
      new Thread(pts).Start(3);

      // nothing to join so wait on user

      Console.Write("\n  Press Key to quit: ");
      Console.ReadKey();
      Console.Write("\n\n");
    }
  }
}
