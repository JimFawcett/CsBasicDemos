/////////////////////////////////////////////////////////////////////
// DemoArrayList.cs - demonstrate basic properties of ArrayList    //
//                                                                 //
// Jim Fawcett, CSE382 - Algorithms and DataStructures, Fall 2008  //
/////////////////////////////////////////////////////////////////////
/*
 * System.Collections.ArrayList wraps an expandable array (contiguous 
 * memory), is indexable, and provides Add, Insert, Remove, RemoveAt,
 * Sort, ... for managing elements.  Add is O(1) if enough capacity exists
 * for adding an element, otherwise O(N).  Insert and Remove are O(N).
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  class DemoArrayList
  {
    static void Main(string[] args)
    {
      Utility.showTitle("Demonstrate Collections.ArrayList");

      ArrayList ar = new ArrayList();
      ar.Capacity = 10;
      ar.Add(1);
      ar.Add(2);
      int[] intcoll = { 3,4,5,6,7,8,9 };
      ar.AddRange(intcoll);
      Console.Write("\n  capacity = {0}", ar.Capacity);
      Utility.show(ar);
      ar.Add(10);
      Console.Write("\n  capacity = {0}", ar.Capacity);
      Utility.show(ar);
      ar.Add(11);
      Console.Write("\n  capacity = {0}", ar.Capacity);
      Utility.show(ar);

      ar.Sort(new Reverse());
      Console.Write("\n  capacity = {0}", ar.Capacity);
      Utility.show(ar);

      Console.Write("\n  value at index {0} is {1}", 3, ar[3]);
      Console.Write(
        "\n  using BinarySearch: index of value {0} is {1}", 
        5, ar.BinarySearch(5, new Reverse())
      );
      Console.Write(
        "\n  using IndexOf:      index of value {0} is {1}", 
        7, ar.IndexOf(7)
      );
      Console.Write("\n\n");
    }
  }
}
