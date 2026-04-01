///////////////////////////////////////////////////////////////////////
// DemoExtensions.cs - Define utility extension methods              //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, F2015       //
///////////////////////////////////////////////////////////////////////
/*
 * Extension methods are static methods of a static class with a peculiar
 * syntax, e.g., static Tr myMethod(this someType instance).  They are
 * appliced to intances of the someType type as if they were members
 * of the someType class.  However, they can only use the public interface
 * of someType.  These are the methods defined here:
 *   1. static public void title(this string aString, char underline='-')
 *      Displays the content of aString on the Console.
 *   2. static public void showMethods(this object anObject)
 *      Displays all the methods of the type supplied as the object argument
 *      using reflection.
 *   3. static public bool isValueType(this object anObject)
 *      returns true if a value type, like int, is the passed argument.
 *   3. static public bool isReferenceType(this object anObject)
 *      returns true if a reference type, like StringBuilder, is the passed
 *      argument.
 *   3. static public void showKindOfType(this object anObject)
 *      displays the kind of type, e.g., value or reference, for the passed
 *      instance.
 */
/*
 * Read pages 162 - 164 in Chap 4 in the class text.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpDemos
{
  /////////////////////////////////////////////////////////////////////
  // helper class BasicExtensions extends strings with title method
  //
  static public class DemoExtensions  // the first argument type "this string" defines the target type
  {
    static public void title(this string astring, char underline = '-')
    {
      Console.Write("\n  {0}", astring);
      Console.Write("\n {0}", new string(underline, astring.Length + 2));
    }
    static public void showMethods(this object anObject)
    {
      Type t = anObject.GetType();
      foreach (var method in t.GetMethods())
        Console.Write("\n  method: {0}", method);
    }
    static public bool isValueType(this object anObject)
    {
      Type t = anObject.GetType();
      return t.IsValueType;
    }
    static public bool isReferenceType(this object anObject)
    {
      Type t = anObject.GetType();
      return !t.IsValueType;
    }
    static public void showKindOfType(this object anObject)
    {
      Type t = anObject.GetType();
      if (anObject.isValueType())
      {
        Write("\n  {0} is ValueType", t.Name);
        return;
      }
      if (anObject.isReferenceType())
      {
        Write("\n  {0} is ReferenceType", t.Name);
        return;
      }
      Write("\n  I don't have a clue about {0}'s kind of type", t.Name);
    }
  }

  class TestDemoExtensions
  {
    static void Main(string[] args)
    {
      "Testing DemoExtensions".title('=');
      WriteLine();

      double d = 2.5;
      "Testing showKindOfType() on double:".title();
      d.showKindOfType();
      WriteLine();

      DemoExtensions.title("Testing showMethods() on double:");
      d.showMethods();
      WriteLine();

      string s = "this is a string";
      "Testing showKindOfType() on string:".title();
      s.showKindOfType();
      WriteLine();

      DemoExtensions.title("Testing showMethods() on string:");
      s.showMethods();
      WriteLine();

      object obj = new object();
      "Testing showKindOfType() on object:".title();
      obj.showKindOfType();
      WriteLine();

      "Testing showMethods() on object:".title();
      obj.showMethods();
      WriteLine();

      TestDemoExtensions tde = new TestDemoExtensions();
      "Testing showKindOfType() on TestDemoExtensions:".title();
      tde.showKindOfType();
      WriteLine();

      "Testing showMethods() on TestDemoExtensions:".title();
      tde.showMethods();
      Write("\n\n");
    }
  }
}
