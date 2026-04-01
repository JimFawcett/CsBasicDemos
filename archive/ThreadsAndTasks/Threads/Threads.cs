///////////////////////////////////////////////////////////////////
// Threads.cs - Demonstrate basic Threads                        //
//                                                               //
// Jim Fawcett, CSE686 - Internet Programming, Spring 2014       //
///////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
  class Threads
  {
    static void printFoo() { Console.Write("\n  foo"); }
    static void Main(string[] args)
    {
      Console.Write("\n  Demo simple thread");
      Console.Write("\n ====================\n");

      // Thread expects ThreadStart delegate

      ThreadStart ts = () => { 
        Console.Write("\n  Hello from thread {0}", Thread.CurrentThread.ManagedThreadId); 
      };
      Thread t1 = new Thread(ts);
      t1.Start();
      t1.Join();

      // ThreadStart delegate inferred from function

      Thread t2 = new Thread(Threads.printFoo);
      t2.Start();
      t2.Join();
      Console.Write("\n  ");

      // ThreadStart delegate inferred from lambda

      for (int i = 0; i < 10; ++i )
      {
        int temp = i;
        new Thread(() => 
          {
            Thread.Sleep(temp % 2);
            Console.Write(temp);
          }).Start();
      }

      Console.Write("\n  Press a key to quit: ");
      Console.ReadKey();

      Console.Write("\n\n");
    }
  }
}
