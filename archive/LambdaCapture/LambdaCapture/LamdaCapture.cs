///////////////////////////////////////////////////////////////////////
// LambdaCapture.cs - demonstrates Lambda capturing its local state  //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2014   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCapture
{
  class LamdaCapture
  {
    /*
     *  This demo illustrates the use of lambda capture.  
     *  ================================================
     *  The processing here is equivalent to making a function inside another function
     *  and passing the made function along with it's local scope into a third function
     *  to be executed there.
     */
    static Action<string> MakeLambda()
    {
      // Things to note:
      // - string localMsg will be captured and transported to using scope
      // - lambdas can bind to delegates with the same signature

      string localMsg = "local message";  
      Action<string> delegateBindingToLambda = (msg) => Console.Write("\n  {0} and {1}", msg, localMsg);
      return delegateBindingToLambda;
    }

    static void UseLamda(Action<string> deleg)
    {
      deleg.Invoke("message from using scope");
    }
    static void Main(string[] args)
    {
      Console.Write("\n  Demonstrating Lambda Capture");
      Console.Write("\n ==============================\n");

      UseLamda(MakeLambda());
      Console.Write("\n");

      // Here's a demo using multiple parameters and multiple statements in a lambda

      Action<string, double> demoDelegate = (msg, pi) => // note type inference of arguments
      { 
        Console.Write("\n  {0} = {1}", msg, pi); 
        Console.Write("\n\n"); 
      };

      demoDelegate.Invoke("pi", 3.1415927);
    }
  }
}
