/////////////////////////////////////////////////////////////////////////
// MT5Q2.cs - asynchronous function with blocking result               //
//                                                                     //
// Jim Fawcett, CSE681 - Software Modeling and Analysis                //
/////////////////////////////////////////////////////////////////////////
/*
 * - Write all the code for a C# asynchronous member function that  
 *   provides a result that will block on client access until thread
 *   finishes computing result.
 *
 * - I expect that this is something like what the .Net Task class does.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Utilities;

namespace MTF15
{
  class MT5Q2
  {
    object locker_ = new object();  // locks the result until ready
    Thread t = null;
    bool running = false;           // Signals that thread is running before
                                    // application can access result (see below).
    int result_ = 0;

    /*
     * This call will block until the child thread releases the lock.
     */
    public int result { get { lock (locker_) { return result_; } } }

    public void runAsynch()
    {
      Func<int> f = () =>
      {
        lock (locker_)  // take lock until result is ready
        {
          running = true;
          for (int i = 0; i < 10; ++i)
          {
            Console.Write("\n  child thread working");
            result_ = result_ + 2;
            Thread.Sleep(100);
          }
          return result_;
        }  // release lock
      };

      ThreadStart ts = () => f.Invoke();
      t = new Thread(ts);
      t.Start();
      while(!running)  // ensure thread is running before leaving lock
      {
        Thread.Sleep(25);
      }
    }
  }
  class TestMT5Q2
  {
    static void Main(string[] args)
    {
      "MT5Q2 - thread with blocking result".title('=');
      MT5Q2 mt5q2 = new MT5Q2();
      mt5q2.runAsynch();

      // accessing result blocks until result is ready

      Console.Write("\n  result = {0}\n\n", mt5q2.result);
    }
  }
}
