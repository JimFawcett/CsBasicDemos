/////////////////////////////////////////////////////////////////////
// Utility.cs - basic display and comparison operations            //
//                                                                 //
// Jim Fawcett, CSE382 - Algorithms and DataStructures, Fall 2008  //
/////////////////////////////////////////////////////////////////////
/*
 * Provides showTitle, show(IEnumerable), show<T>(IEnumerable),
 * show(IDictionary), show(IDictionaryEntry[]), Reverse.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  public class Utility
  {
    public static void showTitle(string title)
    {
      Console.Write("\n  {0}", title);
      StringBuilder under = new StringBuilder();
      for (int i = 0; i < title.Length + 2; ++i)
        under.Append('=');
      Console.Write("\n {0}\n", under.ToString());
    }
    public static void show(IEnumerable en)
    {
      Console.Write("\n  ");
      foreach (Object o in en)
        Console.Write("{0} ", o.ToString());
      Console.WriteLine();
    }
    public static void show<T>(IEnumerable en)
    {
      Console.Write("\n  ");
      foreach (T t in en)
        Console.Write("{0} ", t.ToString());
      Console.WriteLine();
    }
    public static void show(IDictionary dict)
    {
      foreach (Object o in dict)
      {
        Console.Write(
          "\n  ({0}, {1}) ",
          ((DictionaryEntry)o).Key, ((DictionaryEntry)o).Value
        );
      }
      Console.WriteLine();
    }
    public static void show(DictionaryEntry[] dict)
    {
      foreach (DictionaryEntry d in dict)
      {
        Console.Write(
          "\n  ({0}, {1}) ",
          ((DictionaryEntry)d).Key, ((DictionaryEntry)d).Value
        );
      }
      Console.WriteLine();
    }
  }
  public class Reverse : IComparer
  {
    int IComparer.Compare(Object x, Object y)
    {
      return ((new CaseInsensitiveComparer()).Compare(y, x));
    }
  }
}
