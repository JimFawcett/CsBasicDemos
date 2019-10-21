/////////////////////////////////////////////////////////////////////////////
// ReflectionDemo.cs - reflection analysis of class, delegate, and lambda  //
// ver 1.1                                                                 //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2016         //
/////////////////////////////////////////////////////////////////////////////
/*
 * Ver 1.1 : 22 Sep 2016
 * - added BindingFlags.static to GetMethods, GetProperties, and GetFields
 *   for extraction of private members
 * - doesn't change the results of this demo, but should be there for
 *   completeness, e.g., for future applications of showTypeDetails
 * Ver 1.0 : 21 Sep 2016
 * - first release
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UtilityExtensions;

namespace ReflectionDemos
{
  using static System.Console;

  public class ReflectionDemo
  {
    //----< explore type details with reflection >-----------------------

    public static void showTypeDetails(Object obj)
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
        System.Reflection.BindingFlags.Static |     // can't create instance of static class
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
        System.Reflection.BindingFlags.Instance |
        System.Reflection.BindingFlags.Static)
      )
        Write("\n  {0}", name);
      WriteLine();

      "It's non-public properties are, using reflection:".title();
      foreach (var name in t.GetProperties(
        System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Instance |
        System.Reflection.BindingFlags.Static)
      )
        Write("\n  {0}", name);
      WriteLine();
      "It's non-public fields are, using reflection:".title();
      foreach (var name in t.GetFields(
        System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Instance |
        System.Reflection.BindingFlags.Static)
      )
        Write("\n  {0}", name);
      WriteLine();
    }

  }
  class Program
  {
    void handleNotifications(string msg)
    {
      Console.Write("\n  notification: {0}", msg);
    }
    static void Main(string[] args)
    {
      Action putLine = () => { Console.Write("\n"); };

      "Demonstrating Reflection".title('=');
      putLine();

      "Reflecting on ReflectionTest class".title();
      putLine();

      ReflectionTest rt = new ReflectionTest();
      ReflectionDemo.showTypeDetails(rt);
      putLine();

      "Reflecting on ReflectionTest's delegate sayHandler".title();
      putLine();

      Program pr = new Program();
      rt.sayHandler += new ReflectionTest.SayHandler(pr.handleNotifications);
      ReflectionDemo.showTypeDetails(rt.sayHandler);
      putLine();

      "Invoking lambda defined in main".title();
      putLine();

      string localMsg = " and localMsg";
      Action<string, bool> act = (msg, boolValue) => {
        Console.Write("\n  this is lambda invocation: \"{0}\"", msg + localMsg);
        Console.Write("\n  second argument is {0}", boolValue);
      };
      act.Invoke("lambda argument", true);
      putLine();

      "Reflecting on lamda bound to Action<string>".title();
      putLine();
      ReflectionDemo.showTypeDetails(act);

      "Reflecting on Action's Target".title();
      putLine();
      ReflectionDemo.showTypeDetails(act.Target);
    }
  }
}
