/////////////////////////////////////////////////////////////////////
// Hashtable.cs - demonstrate basic properties of Hashtable        //
//                                                                 //
// Jim Fawcett, CSE382 - Algorithms and DataStructures, Fall 2008  //
/////////////////////////////////////////////////////////////////////
/*
 * System.Collections.Hashtable wraps expandable array with buckets,
 * and hashes key to find bucket address to store value, provides Add,
 * ContainsKey, ContainsValue, IndexOfKey, IndexOfValue, this[key],
 * Count, CopyTo, ... for managing elements.  Operations are O(1).
 * Hashtable does not support duplicate keys.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  class DemoHashtable
  {
    static void Main(string[] args)
    {
      Utility.showTitle("Demonstrate Collections.Hashtable");

      Hashtable S = new Hashtable();
      S.Add("first", 1.5);
      S.Add("second", 2.0);
      S["third"] = 2.5;
      S["fourth"] = 3.0;
      S["fifth"] = 3.5;
      Utility.show(S);
      S["fourth"] = 3.75;
      Utility.show(S);

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
