///////////////////////////////////////////////////////////////////
// TaskWithContinuation.cs - Demonstrate Tasks and Continuations //
//                                                               //
// Jim Fawcett, CSE686 - Internet Programming, Spring 2014       //
///////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskWithContinuation
{
  class TaskWithContinuation
  {
    //----< synchronous function >-----------------------------
    static int getSum(int start)
    {
      Console.Write("\n  Thread id = {0}", Thread.CurrentThread.ManagedThreadId);
      for (int i = 0; i < 1000000; ++i)
        start += i;
      return start;
    }
    //----< Asynchronous call of synchronous function >--------
    static Task<int> getSumAsync(int start)
    {
      return (Task<int>)Task.Run(() =>
        {
          return getSum(start);
        });
    }
    //----< returns immediately after calling await >----------
    static async void getSumWithAwaitAsync(int start)
    {
      var result = await getSumAsync(start);

      // compiler turns this into a continuation

      Console.Write("\n  await has completed with result = {0}", result);
    }
    static void Main(string[] args)
    {
      Console.Write("\n  Task with Continuation");
      Console.Write("\n ========================\n");

      // Returns immediately - continuation will be called when complete

      int Sum = 0;
      Task<int> sumer = Task.Run(() => 
      { 
        return getSum(Sum); 
      });

      // Here's the continuation - when called it doesn't block because result is ready

      var awaiter = sumer.GetAwaiter();
      awaiter.OnCompleted(() => 
      {
        Console.Write("\n  From task thread - Sum = {0}", awaiter.GetResult()); 
      });

      // Running synchronously from main thread

      Console.Write("\n  From main thread - Sum = {0}", getSum(100));

      Console.Write("\n  Press key to continue: ");

      // Returns immediately - can get result later

      Task<int> task = getSumAsync(200);

      // task.Result blocks until task has completed

      Console.Write("\n  Result from getSumAsyn = {0}", task.Result);

      // Returns immediately - continuation will complete later

      getSumWithAwaitAsync(300);

      Console.Write("\n  Press key to exit");
      Console.ReadKey();
      Console.Write("\n\n");
    }
  }
}
