///////////////////////////////////////////////////////////////////////
// Dictionary.cs - demo basic properties of Dictionary<TKey, TValue> //
//                                                                   //
// Jim Fawcett, CSE681 - Algorithms and DataStructures, Fall 2010    //
///////////////////////////////////////////////////////////////////////
/*
 * System.Collections.Generic.Dictionary is a generic wrapper for a hashtable,
 * with TKey and TValue generic types, provides Add, Remove, Clear,
 * ContainsKey, ContainsValue, and GetEnumerator.  Dictionary also provides
 * properties: Count, Item, Keys, and Values.  Item is indexed by a key.
 * Add, Remove, Item, etc, are O(1).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  class DemoDictionary
  {
    static void Main(string[] args)
    {
      Utility.showTitle("Demonstrate Collections.Generic.Dictionary");

      Dictionary<string, int> dict = new Dictionary<string, int>();
      dict["zero"] = 0;
      dict["one"] = 1;
      dict["two"] = 2;
      dict["three"] = 3;
      dict["four"] = 4;
      Console.Write("\n  the value of key \"two\" is {0}\n", dict["two"]);
      
      Console.Write("\n  the dictionary holds keys:");
      Console.Write("\n  ");
      foreach (string key in dict.Keys)
        Console.Write("{0} ", key);
      Console.Write("\n");

      Console.Write("\n  the dictionary holds values:");
      Console.Write("\n  ");
      foreach (string key in dict.Keys)
        Console.Write("{0} ", dict[key]);
      Console.Write("\n");

      Console.Write("\n  Dictionary values can be containers:");
      int[] temp1 = { 1, 2, 3, 4, 5 };
      List<int> l1 = new List<int>(temp1);
      int[] temp2 = { 2, 3, 4, 5 };
      List<int> l2 = new List<int>(temp2);
      Dictionary<string, List<int>> dictColl = new Dictionary<string, List<int>>();
      dictColl.Add("first", l1);
      dictColl.Add("second", l2);
      Console.Write("\n  the type of dictColl is Dictionary<string, List<int>>");
      Console.Write("\n  it contains:");
      foreach (string key in dictColl.Keys)
      {
        Console.Write("\n  {0}:", key);
        foreach (int i in dictColl[key])
          Console.Write(" {0}", i);
      }
      Console.Write("\n\n");
    }
  }
}
