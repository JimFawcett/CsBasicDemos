///////////////////////////////////////////////////////////////////////
// GenericsDemo.cs - shows how to define and use a generic class     //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, F2015       //
///////////////////////////////////////////////////////////////////////
/*
 *  A generic type has one or more type parameters that are not specified.
 *  until a client creates an instance of the type.
 */
/*
 * Read pages 106 - 118 in Chap 3 of the class text.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpDemos
{
  public class SimpleType<T>  // T is undefined until we get to Main
  {
    private T gt;
    public SimpleType(T t) { gt = t; }
    public void say()
    {
      gt.showKindOfType();
      Write("\n  ToString(): {0}", gt.ToString());
    }
  }
  public class EnumerableType<T,U> where T : IEnumerable<U>  // a constraint
  {
    private T gt;
    public EnumerableType(T t) { gt = t; }
    public void say()
    {
      gt.showKindOfType();
      foreach (U item in gt)
      {
        Write("\n  ToString(): {0}", item);
      }
    }
  }
  class GenericsDemo
  {
    static void Main(string[] args)
    {
      "Testing GenericsDemo".title('=');
      WriteLine();

      "Testing SimpleType<int>:".title();
      SimpleType<int> sti = new SimpleType<int>(3);
      sti.say();
      WriteLine();

      "Testing SimpleType<double>:".title();
      SimpleType<double> std = new SimpleType<double>(3.1415927);
      std.say();
      WriteLine();

      "Testing EnumerableType<List<string>, string>:".title();
      EnumerableType<List<string>, string> stl = 
        new EnumerableType<List<string>, string>(new List<string> { "one", "two", "three" });
      stl.say();
      Write("\n\n");
    }
  }
}
