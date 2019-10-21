/////////////////////////////////////////////////////////////////////
// Stack.cs - demonstrate basic properties of Stack<T>             //
//                                                                 //
// Jim Fawcett, CSE382 - Algorithms and DataStructures, Fall 2008  //
/////////////////////////////////////////////////////////////////////
/*
 * System.Collections.Generic.Stack wraps an expandable circular array
 * (contiguous memory) and provides Push, Pop, Peek, Clear, Count,
 * ToArray, ... for managing elements.  Operations are O(1) unless
 * more capacity is needed, then O(N).
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  class DemoStack
  {
    static void Main(string[] args)
    {
      Utility.showTitle("Demonstrate Collections.Generic.Stack");

      Stack<double> S = new Stack<double>();
      S.Push(1.5);
      S.Push(2.0);
      S.Push(2.5);
      S.Push(3.0);
      S.Push(3.5);
      Utility.show<double>(S.ToArray());

      int len = S.Count;
      for (int i = 0; i < len; ++i)
      {
        Console.Write("\n  popping {0}", S.Pop());
      }
      try
      {
        Console.Write("\n  popping {0}", S.Pop());
      }
      catch (Exception ex)
      {
        Console.Write("\n  Exception thrown: {0}", ex.Message);
      }
      Console.Write("\n\n");
    }
  }
}
