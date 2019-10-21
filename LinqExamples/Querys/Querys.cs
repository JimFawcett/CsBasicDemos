///////////////////////////////////////////////////////////////
// Querys.cs - Demonstrate Linq Querys on Collections        //
//                                                           //
// Jim Fawcett, CSE775 - Distributed Objects, Spring 2009    //
///////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Querys
{
  class QueryExamples
  {
    static void title(string msg)
    {
      Console.Write("\n  {0}", msg);
      Console.Write("\n {0}",new String('-',msg.Length+2));
    }
    static void show(IEnumerable<int> result)
    {
      Console.Write("\n  ");
      foreach (int n in result)
        Console.Write("{0} ", n);
      Console.Write("\n");
    }
    static void NumsValues(int[] nums)
    {
      title("nums values");
      show(nums);
    }
    static void QuerySyntax(int[] nums)
    {
      title("Query Syntax");

      var result = from n in nums
                   where n < 10
                   orderby n
                   select n;
      show(result);
    }

    static void ExtensionMethodSyntax(int[] nums)
    {
      title("Extension Method Syntax");

      var result = nums
                   .Where(n => n < 10)
                   .OrderBy(n => n);
      show(result);
    }

    static void QueryDotSyntax(int[] nums)
    {
      title("Query dot Syntax");

      var result = (nums
                   .Where(n => n < 10)
                   .OrderBy(n => n)).Distinct();
      show(result);
    }

    static void IQueryableExtensionMethods(int[] nums)
    {
      title("IQueryable Extension Methods");
      Console.Write("\n  nums size is: {0}", nums.Count());
      Console.Write("\n  nums sum  is: {0}", nums.Sum());
      Console.Write("\n  nums avg  is: {0}", nums.Average());
      Console.Write("\n  nums max  is: {0}", nums.Max());
      Console.Write("\n  nums min  is: {0}", nums.Min());
      Console.Write("\n  nums unique:");
      var result = nums.Distinct();
      show(result);
      Console.WriteLine();
    }

    static void Main(string[] args)
    {
      int[] nums = { 2, -15, 7, 33, -15, 85, -27, -10, 9 };

      NumsValues(nums);
      QuerySyntax(nums);
      ExtensionMethodSyntax(nums);
      QueryDotSyntax(nums);
      IQueryableExtensionMethods(nums);
      Console.WriteLine();
    }
  }
}
