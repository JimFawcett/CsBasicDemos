/////////////////////////////////////////////////////////////////////
// Queue.cs - demonstrate basic properties of Queue<T>             //
//                                                                 //
// Jim Fawcett, CSE382 - Algorithms and DataStructures, Fall 2008  //
/////////////////////////////////////////////////////////////////////
/*
 * System.Collections.Generic.Queue wraps an expandable circular array
 * (contiguous memory) and provides Enqueue, Dequeue, Peek, Clear,
 * Count, ToArray, ... for managing elements.  Operations are O(1)
 * unless more capacity is needed, then O(N).
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  class DemoQueue
  {
    static void Main(string[] args)
    {
      Utility.showTitle("Demonstrate Collections.Generic.Queue");

      Queue<double> Q = new Queue<double>();
      Q.Enqueue(1.5);
      Q.Enqueue(2.0);
      Q.Enqueue(2.5);
      Q.Enqueue(3.0);
      Q.Enqueue(3.5);
      Utility.show<double>(Q.ToArray());

      int len = Q.Count;
      for (int i = 0; i < len; ++i)
      {
        Console.Write("\n  dequeuing {0}", Q.Dequeue());
      }
      try
      {
        Console.Write("\n  dequeuing {0}", Q.Dequeue());
      }
      catch (Exception ex)
      {
        Console.Write("\n  Exception thrown: {0}", ex.Message);
      }
      Console.Write("\n\n");
    }
  }
}
