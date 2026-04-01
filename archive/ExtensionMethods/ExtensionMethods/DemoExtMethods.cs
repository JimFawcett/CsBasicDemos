/////////////////////////////////////////////////////////////////////
// DemoExtMethods.cs - Demonstrate .Net Extension Methods          //
//                                                                 //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2011 //
/////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
  public static class DemoExtMethods
  {
    public static string myType(this Object obj)
    {
      return obj.GetType().Name;
    }
    public static void show(this Object obj)
    {
      Console.Write("\n  Type: {0,-10} Value: {1}", obj.myType(), obj.ToString());
    }
    public static double mag(this IEnumerable<double> col)
    {
      double sum = 0;
      foreach (double d in col)
        sum += d*d;
      return Math.Sqrt(sum);
    }
    static void Main(string[] args)
    {
      Console.Write("\n  Demonstrate Extension Methods");
      Console.Write("\n ===============================");

      string s = "a string";
      s.show();
      Int16 i = 3;
      i.show();
      Action<string> act = str => Console.Write(str);
      act.show();
      double[] dbls = { 1, 2, 3 };
      Console.Write("\n  vector length:   {0}",dbls.mag());
      Console.Write("\n\n");
    }
  }
}
