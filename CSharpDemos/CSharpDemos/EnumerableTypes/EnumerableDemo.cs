///////////////////////////////////////////////////////////////////////
// EnumerableDemo.cs - shows basic characteristics of an Enumerable  //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, F2015       //
///////////////////////////////////////////////////////////////////////
/*
 *  An enumerable type implements the IEnumerable<T> interface.  
 *  Enumerable types can be the visited by the foreach control because
 *  it implements the method GetEnumerator() which returns an enumeration
 *  object that has method MoveNext() and property Current, both used
 *  by foreach.
 */
/*
 * Read Chap 7 in the class text.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;  // this only works with C# 6.0

namespace CSharpDemos
{
  class EnumerableDemo
  {
    static void Main(string[] args)
    {
      "Demonstrating Enumerables".title('=');
      WriteLine();

      List<string> ls = new List<string>(new[] { "one", "two", "three", "four" });

      //ls.showMethods();
      //WriteLine();

      "Using foreach:".title();
      foreach (var item in ls)
        Write("\n  item: {0}", item);
      WriteLine();

      "Using enumeration directly:".title();
      var enumerator = ls.GetEnumerator();
      // enumerator.showMethods();
      // WriteLine();

      enumerator.MoveNext();
      do
        Write("\n  item: {0}", enumerator.Current);
      while (enumerator.MoveNext()) ;
      Write("\n\n");
    }
  }
}
