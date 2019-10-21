/////////////////////////////////////////////////////////////////////
// LinkedList.cs - demonstrate basic properties of LinkedList<T>   //
//                                                                 //
// Jim Fawcett, CSE382 - Algorithms and DataStructures, Fall 2008  //
/////////////////////////////////////////////////////////////////////
/*
 * System.Collections.Generic.LinkedList implements a doubly linked 
 * generic list, and provides AddFront, AddBack, AddBefore, AddAfter,
 * Remove, RemoveFirst, RemoveLast, Find, FindLast, ... for managing
 * elements.  Operations are O(N).
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetContainers
{
  class DemoLinkedList
  {
    static void Main(string[] args)
    {
      Utility.showTitle("Demonstrate Collections.Generic.LinkedList");

      LinkedList<string> S = new LinkedList<string>();
      S.AddFirst("first");
      S.AddFirst("second");
      S.AddLast("third");
      S.AddLast("fourth");
      S.AddLast("fifth");
      Utility.show(S);

      LinkedListNode<string> node = S.Find("fifth");
      S.AddBefore(node, "before_fifth");
      S.AddAfter(node, "after_fifth");
      Utility.show(S);

      Console.Write("\n  removing front item:");
      S.RemoveFirst();
      Utility.show(S);

      Console.Write("\n  removing \"third\"");
      S.Remove("third");
      Utility.show(S);

      Console.Write("\n");
    }
  }
}
