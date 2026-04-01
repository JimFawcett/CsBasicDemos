/////////////////////////////////////////////////////////////////////
// HashSet.cs - demonstrate basic properties of HashSet<T>         //
//                                                                 //
// Jim Fawcett, CSE382 - Algorithms and DataStructures, Fall 2008  //
/////////////////////////////////////////////////////////////////////
/*
 * System.Collections.Generic.HashSet wraps expandable array with buckets,
 * and hashes key to find bucket address to store, provides Add,
 * ContainsKey, ContainsValue, IndexOfKey, IndexOfValue, this[key],
 * Count, CopyTo, ... for managing elements.  Operations are O(1).
 * HashSet does not support duplicate keys.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  class DemoHashSet
  {
    static void Main(string[] args)
    {
      Utility.showTitle("Demonstrate Collections.Generic.HashSet");

      HashSet<string> S = new HashSet<string>();
      S.Add("first");
      S.Add("second");
      S.Add("third");
      S.Add("fourth");
      S.Add("fifth");
      Utility.show(S);
      
      // adding key again does nothing
      S.Add("fourth");

      string key = "third";
      if(S.Contains(key))
        Console.Write("\n  HashSet contains {0}", key);
      else
        Console.Write("\n  HashSet does not contain {0}", key);

      Console.Write("\n  Removing item \"{0}\":", key);
      S.Remove(key);
      Utility.show(S);

      if(S.Contains(key))
        Console.Write("\n  HashSet contains {0}", key);
      else
        Console.Write("\n  HashSet does not contain {0}", key);

      Console.Write("\n\n");
    }
  }
}
