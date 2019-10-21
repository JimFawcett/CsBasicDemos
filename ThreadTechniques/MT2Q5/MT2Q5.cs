/////////////////////////////////////////////////////////////////////////
// MT2Q5.cs - asynchronous function with callback                      //
//                                                                     //
// Jim Fawcett, CSE681 - Software Modeling and Analysis                //
/////////////////////////////////////////////////////////////////////////
/*
 * Write all the code for a C# asynchronous function that accepts a 
 * user defined callback function and calls it when its main task has
 * completed.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MTF15
{
  using Utilities;

  public class AsyncWithCallback
  {
    Action doMainTask = null;
    Thread t;

    public AsyncWithCallback()
    {
      doMainTask = () => { Console.Write("\n  I'm busy doing work"); };
    }
    public void asyncRun(Action callback)
    {
      ThreadStart ts = () =>
      {
        doMainTask.Invoke();
        if(callback != null)
          callback.Invoke();
      };
      t = new Thread(ts);
      t.Start();
    }
    public void join() { t.Join(); }
  }
  class MT2Q5
  {
    public void myCallbackHandler()
    {
      Console.Write("\n  I'm being called back");
    }
    static void Main(string[] args)
    {
      "MT2Q5 - Asynchronous function that calls back when done".title('=');
      MT2Q5 mt2q5 = new MT2Q5();
      Action callback = () => { mt2q5.myCallbackHandler(); };
      AsyncWithCallback cb = new AsyncWithCallback();
      cb.asyncRun(callback);
      Console.Write("\n  waiting for async to finish");
      cb.join();
      Console.Write("\n\n");
    }
  }
}
