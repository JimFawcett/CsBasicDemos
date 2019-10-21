/////////////////////////////////////////////////////////////////////
// SortedList.cs - demonstrate basic properties of SortedList      //
//                                                                 //
// Jim Fawcett, CSE382 - Algorithms and DataStructures, Fall 2008  //
/////////////////////////////////////////////////////////////////////
/*
 * System.Collections.SortedList wraps two expandable arrays (contiguous
 * memory) for keys and values, and provides Add, Contains, GetKey(index),
 * IndexOfKey, this[key], Count, CopyTo, ... for managing elements.
 * Operations are O(N).  SortedList does not allow duplicate keys.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  class DemoSortedList
  {
    static void Main(string[] args)
    {
      Utility.showTitle("Demonstrate Collections.SortedList");

      SortedList S = new SortedList();
      S.Add("first",1.5);
      S.Add("second",2.0);
      S.Add("third",2.5);
      S.Add("fourth",3.0);
      S.Add("fifth",3.5);
      Utility.show(S);

      Console.Write(
        "\n  index of key {0} is {1}",
        "\"third\"", S.IndexOfKey("third")
      );

      Console.Write(
        "\n  value of key {0} is {1}",
        "\"third\"", S["third"]
      );

      Console.WriteLine();
      DictionaryEntry[] values = new DictionaryEntry[S.Count];
      S.CopyTo(values, 0);
      Utility.show(values);

      Console.Write("\n");
    }
  }
}
