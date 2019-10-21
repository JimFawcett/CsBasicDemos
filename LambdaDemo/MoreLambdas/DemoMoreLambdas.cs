/////////////////////////////////////////////////////////////////////////
// DemoMoreLambdas.cs - Capture revisited                              //
//                                                                     //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2015     //
/////////////////////////////////////////////////////////////////////////
/*
 * This example demonstrates that instances of types captured by a lambda
 * are not immutable.  That is true for both reference and value types.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityExtensions;
using static System.Console;

namespace MoreLambdas
{
  class DemoMoreLambdas
  {
    public int demoIntFromClassScope { get; set; } = 42;
    public string demoStringFromClassScope { get; set; } = "this is a demo string";

    public void anotherScope(Action act)
    {
      "\n  invoking delegate in function \"anotherScope(Action act)\"".title();
      act.Invoke();
    }

    static void Main(string[] args)
    {
      int demoIntFromLocalScope = -7;
      string demoStringFromLocalScope = "local string";

      "LambdaDemo.MoreLambdas - Demonstrating behavior of captured variables".title('=');
      DemoMoreLambdas dml = new DemoMoreLambdas();

      Action act = new Action(() =>
      {
        Write("\n     int property from class = {0}", dml.demoIntFromClassScope);
        Write("\n  string property from class = {0}", dml.demoStringFromClassScope);
        Write("\n               int from main = {0}", demoIntFromLocalScope);
        Write("\n            string from main = {0}", demoStringFromLocalScope);
      });

      "\n  Invoking delegate in Main's scope".title();
      act.Invoke();
      dml.anotherScope(act);
      WriteLine();

      "Changing class properties and local data".title();
      dml.demoIntFromClassScope = 21;
      dml.demoStringFromClassScope = "still another demo string";
      demoIntFromLocalScope = -14;
      demoStringFromLocalScope = "still another local string";

      "\n  Invoking delegate in Main's scope".title();
      act.Invoke();
      dml.anotherScope(act);

      Write("\n\n");
    }
  }
}
