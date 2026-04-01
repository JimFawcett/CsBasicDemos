/////////////////////////////////////////////////////////////////////////////
// Delegates.cs - Delegate Shortcuts start to look like function pointers  //
//                                                                         //
// Version 2.1 - added commentary about = and += operators                 //
// Version 2.0 - fixed typo spotted by Phil Tricca, added Func<T,TResult>  //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2008         //
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace delegates
{
  public class DemoDelegates
  {
    delegate void SimpleTraditional(string msg);

    void handler(string msg)
    {
      Console.Write("\n  {0}",msg);
    }
    static void Main(string[] args)
    {
      Console.Write("\n  Demonstrating new delegate shortcuts and LINQ");
      Console.Write("\n -----------------------------------------------\n");

      DemoDelegates pr = new DemoDelegates();

      // traditional delegate

      SimpleTraditional trad = new SimpleTraditional(pr.handler);
      trad += new SimpleTraditional(pr.handler);
      trad += new SimpleTraditional(pr.handler);
      
      // The = operator creates a new delegate list with one element.
      // The += operator adds the new delegate to the existing list.

      // You should see the handler message repeated three times
      // If you uncomment the line below you will only see one
      // since the + operator will replace the list with this
      // new delegate, e.g., a list of one delegate

      //trad = new SimpleTraditional(pr.handler);
      
      trad.Invoke("traditional message");

      // short cut looks like function pointer but is delegate

      SimpleTraditional shortcut = pr.handler;
      shortcut.Invoke("shortcut message");

      // anonymous delegate defines handling activity locally

      SimpleTraditional anon = delegate(string msg)
      {
        Console.Write("\n  {0}", msg);
      };
      anon.Invoke("anonymous message");

      // Action is a predefined delegate of the form:
      // delegate void Action<T>(T t);

      Action<string> act = pr.handler;
      act.Invoke("action's message");

      // Action delegate defined using LINQ Lambda expression

      Action<string> LINQact = msg => Console.Write("\n  {0}", msg);
      LINQact.Invoke("LINQ action's message");

      // Func is a predefined delegate of the form:
      // delegate T Func(T t1, T t2);

      Console.Write("\n\n  Func<T1,T2,TResult>:");
      Func<int, int, int> add_i = (int t1, int t2) => t1 + t2;
      Console.Write("\n  add({0},{1}) = {2}", 3, 5, add_i.Invoke(3, 5));
      Func<double, double, double> add_d = (double t1, double t2) => t1 + t2;
      Console.Write("\n  add({0},{1}) = {2}", 3.75, 18.5, add_d.Invoke(3.75, 18.5));

      Console.Write("\n  Func<T,TResult>:");
      Func<double, int> trunc_d
        = (double d) => (int)d;
      Console.Write("\n  trunc({0}) = {1}", 3.75, trunc_d.Invoke(3.75));

      Console.Write("\n\n");
    }
  }
}
