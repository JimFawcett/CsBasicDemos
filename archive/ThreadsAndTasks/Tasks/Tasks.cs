///////////////////////////////////////////////////////////////////
// Tasks.cs - Demonstrate basic Tasks                            //
//                                                               //
// Jim Fawcett, CSE686 - Internet Programming, Spring 2014       //
///////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tasks
{
  class Tasks
  {
    static int activity(string msg)
    {
      Console.Write("\n  my message = {0}", msg);
      return Thread.CurrentThread.ManagedThreadId;
    }
    static void Main(string[] args)
    {
      Console.Write("\n  Basic Tasks");
      Console.Write("\n =============\n");

      // Task with no arguments and no return value

      Task.Run(() => Console.Write("\n  Hello from thread pool"));

      // Concurrent tasks with no arguments and no return values

      for(int i=0; i<5; ++i)
      {
        Task.Run(() => 
          Console.Write("\n  Hello from thread {0}", Thread.CurrentThread.ManagedThreadId)
        );
      }


      // Task with string argument and int return value

      string msg = "hello from main";  // value captured by lambda closure

        // Task runs asynchronously on thread pool thread

      Task<int> task = Task.Run(() => { return Tasks.activity(msg); });

        // task is a future and Result blocks until thread completes

      int id = task.Result;
      Console.Write("\n  task's thread id = {0}", id);

      Console.Write("\n  Press key to exit: ");
      Console.ReadKey();
      Console.Write("\n\n");
    }
  }
}
