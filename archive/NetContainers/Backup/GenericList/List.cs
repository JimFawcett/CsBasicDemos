/////////////////////////////////////////////////////////////////////
// List.cs - demonstrate basic properties of List<T>             //
//                                                                 //
// Jim Fawcett, CSE382 - Algorithms and DataStructures, Fall 2008  //
/////////////////////////////////////////////////////////////////////
/*
 * System.Collections.Generic.List is a generic form of ArrayList.
 * It wraps an expandable circular array (contiguous memory) and
 * provides Add, this[index], Count, Remove, RemoveAt, ToArray, ...
 * for managing elements.  Operations are O(N).
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  class DemoList
  {
    static void Main(string[] args)
    {
      Utility.showTitle("Demonstrate Collections.Generic.List");

      List<double> L = new List<double>();
      L.Add(1.5);
      L.Add(2.0);
      L.Add(2.5);
      L.Add(3.0);
      L.Add(3.5);
      Utility.show<double>(L.ToArray());

      Console.Write("\n  value at index {0} is {1}", 2, L[2]);
      Console.WriteLine();

      int len = L.Count;
      for (int i = 0; i < len; ++i)
      {
        Console.Write("\n  RemoveAt({0})", 0);
        L.RemoveAt(0);
        Utility.show(L);
      }
      try
      {
        Console.Write("\n  RemoveAt({0})", 0);
        L.RemoveAt(0);
      }
      catch (Exception ex)
      {
        Console.Write("\n  Exception thrown: {0}", ex.Message);
      }
      Console.Write("\n\n");
    }
  }
}
