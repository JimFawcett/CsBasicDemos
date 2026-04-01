/////////////////////////////////////////////////////////////////////////
// MT1Q2.cs - Thread with enqueued tasks                               //
//                                                                     //
// Jim Fawcett, CSE681 - Software Modeling and Analysis                //
/////////////////////////////////////////////////////////////////////////
/*
 * Write all the code for a C# thread that reads a queue to
 * get a task to execute.
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

  class MT1Q2
  {
    public SWTools.BlockingQueue<Action> bQ { get; set; } 
      = new SWTools.BlockingQueue<Action>();

    /*
     * This is the most important part of a thread pool.
     * The only additional work necessary is to create
     * a set of threads that all use this function to
     * define their work.
     */
    void ThreadProc()
    {
      while(true)
      {
        Action act = bQ.deQ();
        if (act == null)
          break;
        act.Invoke();
      }
    }
    static void Main(string[] args)
    {
      "MT1Q2 - thread that runs queued work items".title('=');
      MT1Q2 mt1q2 = new MT1Q2();
      ThreadStart ts = mt1q2.ThreadProc;
      Thread t = new Thread(ts);
      t.Start();

      Action act1 = () => {
        for(int i=0; i<3; ++i)
        {
          Console.Write("\n  doing first task");
        }
        Console.Write("\n  finished first task");
      };
      mt1q2.bQ.enQ(act1);
      Action act2 = () => { Console.Write("\n  finished second task"); };
      act2 += () => { Console.Write("\n  now I'm done"); };
      mt1q2.bQ.enQ(act2);
      mt1q2.bQ.enQ(null);  // no more tasks
      t.Join();
      Console.Write("\n\n");
    }
  }
}
