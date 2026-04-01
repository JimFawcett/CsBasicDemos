/////////////////////////////////////////////////////////////////////////
// ShortCuts.cs - Anonymous Initialization and LINQ Queries            //
//                                                                     //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2008     //
/////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtherShortCuts
{
  class ShortCuts
  {
    class Course
    {
      // property shortcuts
      public string Program { get; set; }
      public int Number { get; set; }
      public string Name { get; set; }
    }

    static void Main(string[] args)
    {
      List<Course> courses = new List<Course>
      {
        // Anonymous initialization
        new Course{ Program = "CSE", Number = 681, Name = "SMA"},
        new Course{ Program = "CSE", Number = 686, Name = "IP"},
        new Course{ Program = "CSE", Number = 687, Name = "OOD"},
        new Course{ Program = "CSE", Number = 775, Name = "DO"},
        new Course{ Program = "CSE", Number = 776, Name = "DP"},
        new Course{ Program = "CSE", Number = 784, Name = "SS"},
      };
      Console.Write("\n  Anonymous Initialization");
      Console.Write("\n ==========================");

      // traditional iteration
      foreach (Course c in courses)
        Console.Write("\n  {0}{1} - {2}", c.Program, c.Number.ToString(), c.Name);

      // LINQ 
      Console.WriteLine();
      Console.Write("\n  LINQ Query");
      Console.Write("\n ============");
      var numbers = from c in courses select new { Num = c.Number };
      foreach (var n in numbers)
        Console.Write("\n  {0}", n.Num);

      Console.Write("\n\n");
    }
  }
}
