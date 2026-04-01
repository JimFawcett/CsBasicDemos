/////////////////////////////////////////////////////////////////////////
// DemoDelegatesAndLambdas.cs - show internal details of delegate      //
//                              bound to a lambda                      //
//                                                                     //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2015     //
/////////////////////////////////////////////////////////////////////////
/*
 * This demo is fairly complex.  You will be rewarded with a deep
 * understanding of delegates and lambdas if you study it carefully.  
 * Cheers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using UtilityExtensions;

namespace LambdaDemo
{
  class DemoDelegatesAndLamdas
  {
    //----< explore types details with reflection >----------------------

    static void showDetails(Object obj)
    {
      "Showing members using reflection".title();

      Type t = obj.GetType();
      Write("\n  name of type is \"{0}\"\n", t.Name);

      "It's public methods are, using reflection:".title();
      foreach (var name in t.GetMethods())
        Write("\n  {0}", name);
      WriteLine();

      "It's public properties are, using reflection:".title();
      foreach (var name in t.GetProperties())
        Write("\n  {0}", name);
      WriteLine();

      "It's public fields are, using reflection:".title();
      foreach (var name in t.GetFields())
        Write("\n  {0}", name);
      WriteLine();

      "It's nested types are, using reflection:".title();
      foreach (var name in t.GetNestedTypes(
        System.Reflection.BindingFlags.Static |
        System.Reflection.BindingFlags.Instance |
        System.Reflection.BindingFlags.Public |
        System.Reflection.BindingFlags.NonPublic
        )
      )
        Write("\n  {0}", name);
      WriteLine();

      "It's non-public methods are, using reflection:".title();
      foreach (var name in t.GetMethods(
        System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Instance)
      )
        Write("\n  {0}", name);
      WriteLine();

      "It's non-public properties are, using reflection:".title();
      foreach (var name in t.GetProperties(
        System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Instance)
      )
        Write("\n  {0}", name);
      WriteLine();
      "It's non-public fields are, using reflection:".title();
      foreach (var name in t.GetFields(
        System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Instance)
      )
        Write("\n  {0}", name);
      WriteLine();
    }
    //----< function illustrates use of capture across scopes >----------

    static void anotherScope(Action<double> act, double d)
    {
      act.Invoke(d);
    }
    //----< Demo Action delegate binding to lambda expression >----------

    static void Main(string[] args)
    {
      "LambdaDemo.LamdaDemo - Demonstrating Lambda Expressions".title('=');
      WriteLine();

      "Binding Lambda with capture to an Action delegate".title();

      int value = 42;  // this value will be captured by the lambda
      double d = 3.1415927;
      d += value;      // this value is used here, but not in lambda so not captured

      // Action<double> is a predefined delegate that can bind to signatures void f(double d)

      double pi = 3.1415927;
      Action<double> act = new Action<double>((pie) => {
        Console.Write("\n  Hello CSE681. My value is {0}", value); /* value used so captured */
        Console.Write("\n  My input parameter is {0}", pie);
      });
      act.Invoke(pi);
      WriteLine();
      "\n  Value was captured by the lambda and stored\n  as a public member of a private class - see below\n".write();

      "Passing delegate to function and invoking to show capture in action".title();
      anotherScope(act, pi);
      "\n\n  Note that main's value is not visible in this function".write();
      "\n  but the lambda can still use value since it was captured\n".write();

      "Now we show internal details of the Action delegate".title('=');
      WriteLine();
      showDetails(act);

      "And the details of the lambda are:".title('=');
      WriteLine();
      showDetails(act.Target);

      Write("\n\n");
    }
  }
}
