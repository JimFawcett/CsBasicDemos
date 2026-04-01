///////////////////////////////////////////////////////////////////////
// QueryExamples.cs - Examples of LINQ to Objects                    //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2013   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
  /////////////////////////////////////////////
  // define custom extension methods

  static class ExtensionMethods
  {
    public static void displayAsTitle(this string titleString, char underlineChar = '-')
    {
      Console.Write("\n  {0}", titleString);
      Console.Write("\n {0}", new string(underlineChar, titleString.Length + 2));
    }

    public static void displayResults(this IEnumerable<string> coll)
    {
      Console.Write("\n  ");
      foreach (string item in coll)
      {
        if (item == coll.First())
          Console.Write("{0}", item);
        else
          Console.Write(", {0}", item);
      }
      Console.Write("\n");
     }
  }

  /////////////////////////////////////////////
  // define class to be used in query

  class course
  {
    public string Program { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public override string ToString() { return Name; }
  }

  class QueryExamples
  {
    static void Main(string[] args)
    {
      "LINQ Examples".displayAsTitle('=');
      Console.WriteLine();

      string[] cars = { "Boxter", "Mini Cooper", "Mustang", "Camaro", "Miata", "Z4" };

      "Using Query Syntax on Array".displayAsTitle();
      var query = 
        from n in cars
        where n.StartsWith("M")
        orderby n
        select n;

      query.displayResults();

      "Using Extension Method Syntax on Array".displayAsTitle();
      IEnumerable<string> query2 = cars
        .Where (n => n.StartsWith("M"))
        .OrderBy (n => n)
        .Select (n => n);

      query2.displayResults();

      List<string> people = new List<string> { "Roosevelt", "Bono", "King", "McCain", "Monroe", "Eiffel" };

      "Using Query Syntax on a List<string>".displayAsTitle();
      var first = people.Take(3);
      var query3 =
        from n in first
        orderby n
        select n.ToUpper();

      query3.displayResults();

      "Using join operator on courses and courseNumbers".displayAsTitle();

      List<course> courses = new List<course>
      {
        new course { Program="CSE", Number=681, Name="SMA" }, 
        new course { Program="CSE", Number=686, Name="IP" }, 
        new course { Program="CSE", Number=687, Name="OOD" }, 
        new course { Program="CSE", Number=775, Name="DO" }, 
        new course { Program="CSE", Number=776, Name="DP" } 
      };

      int[] courseNumbers = { 681, 687, 776 };

      var query4 =
        from n in courseNumbers
        join c in courses on n equals c.Number
        select c.Name;

      query4.displayResults();

      Console.Write("\n\n");
    }
  }
}
