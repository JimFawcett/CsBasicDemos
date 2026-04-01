/////////////////////////////////////////////////////////////////////////
// MT4Q7.cs - stoppable asynchronous function                          //
//                                                                     //
// Jim Fawcett, CSE681 - Software Modeling and Analysis                //
/////////////////////////////////////////////////////////////////////////
/*
 * Write all the code for a C# asynchronous member function that can 
 * be stopped by the using application before completing all its processing.
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

  public class Stoppable
  {
    Thread t = null;
    object sync_ = new object();  // locks the shared signal variable
    Action act_ = null;           // application defined thread processing
    bool stop = false;            // shared signal variable

    public void setAction(Action act) { act_ = act; }
    public void join() { t.Join(); }
    public void doStop()  // main thread uses to set the stop signal
    {
      lock(sync_) { stop = true; }
    }
    bool stopping()       // child thread uses to test the stop signal
    {
      lock(sync_) { return stop; }
    }
    public void asyncRun()
    {
      ThreadStart ts = () =>
      {
        while (true)
        {
          if (act_ == null || stopping())
            break;
          act_.Invoke();
          Thread.Sleep(5);
        }
      };
      t = new Thread(ts);
      t.Start(); 
    }
  }
  class MT4Q7
  {
    static void Main(string[] args)
    {
      "MT4Q7 - Stoppable Asynchronous Function".title('=');
      Stoppable s = new Stoppable();
      Action act = () => Console.Write("\n  I'm running");
      s.setAction(act);
      s.asyncRun();
      Thread.Sleep(100);
      Console.Write("\n  -- stopping now --");
      s.doStop();
      s.join();
      Console.Write("\n\n");
    }
  }
}
