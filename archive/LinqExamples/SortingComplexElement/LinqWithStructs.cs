///////////////////////////////////////////////////////////////////////////
// LinqWithStructs.cs - demonstrate LINQ queries into arrays of structs  //
//                                                                       //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2010       //
///////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingComplexElement
{
  class LinqWithStructs
  {
    public struct elem
    {
      public string name;
      public string town;
      public int yearsKnown;
    };

    elem[] elements = new elem[] 
    { 
      new elem { name = "john", town = "tucson", yearsKnown = 10 }, 
      new elem { name = "fred", town = "chicago", yearsKnown = 3 },
      new elem { name = "mary", town = "syracuse", yearsKnown = 1 } 
    };

    void show(IEnumerable<elem> q)
    {
      foreach (var r in q)
        Console.Write("\n  {0}, {1}, {2}",r.name, r.town, r.yearsKnown);
    }

    static void Main(string[] args)
    {
      Console.Write("\n  Demonstrate LINQ Queries into arrays of structs");
      Console.Write("\n =================================================\n");

      LinqWithStructs p = new LinqWithStructs();

      Console.Write("\n  Order by name");
      Console.Write("\n ---------------");
      var q = from e in p.elements
              orderby e.name
              select e;
      p.show(q);

      Console.Write("\n\n  Order by town");
      Console.Write("\n ---------------");
      q = from e in p.elements
              orderby e.town
              select e;
      p.show(q);

      Console.Write("\n\n  Order by yearsKnown");
      Console.Write("\n ---------------------");
      q = from e in p.elements
              orderby e.yearsKnown
              select e;
      p.show(q);

      Console.Write("\n\n");
    }
  }
}
