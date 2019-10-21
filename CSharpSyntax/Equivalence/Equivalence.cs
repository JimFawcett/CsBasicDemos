///////////////////////////////////////////////////////////////////////
// Equivalence.cs - Demonstrate four types of equivalence tests      //
//                                                                   //
// version 2 - fixes logical inconsistency observed by Phil Tricca   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2008   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Equivalence
{
  class Student
  {
    public string Name
    {
      get;
      set;
    }
    public override bool Equals(Object o)
    {
      Student s = o as Student;
      return (s.Name == this.Name);
    }
  }
  class Equivalence
  {
    static void Compare(Object o1, Object o2)
    {
      Console.Write("\n  static bool ReferenceEquals(object,object) returns {0}", Object.ReferenceEquals(o1, o2));
      Console.Write("\n  static bool Equals(object,object) returns {0}", Object.Equals(o1, o2));
      Console.Write("\n  bool Equals(object) returns {0}", o1.Equals(o2));
      Console.Write("\n  bool operator==(object) returns {0}", o1 == o2);
    }
    static void CompareReferenceEquals<T>(T t1, T t2)
    {
      // do references s1 and s2 point to the same object
      if (t1 is Student)  // t1 and t2 are same type so only need to check one
      {
        Student s1 = t1 as Student;
        Student s2 = t2 as Student;
        if (Object.ReferenceEquals(s1, s2))
          Console.Write("\n  Student {0} and Student {1} have the same identity", s1.Name, s2.Name);
        else
          Console.Write("\n  Student {0} and Student {1} have different identities", s1.Name, s2.Name);
      }
      else
      {
        Type tp1 = t1.GetType(), tp2 = t2.GetType();
        if(tp1.IsValueType && tp2.IsValueType)
        {
          // arguments are boxed so will always be different objects
          if (Object.ReferenceEquals(t1, t2))
            Console.Write("\n  input {0} and input {1} have the same identity", t1, t2);
          else
            Console.Write("\n  input {0} and input {1} have different identities", t1, t2);
        }
      }
    }
    static void Main(string[] args)
    {
      Student s1 = new Student { Name = "Zhe" };
      Student s2 = new Student { Name = "Ashok" };
      Console.Write("\n  Comparing equivalence tests for identical reference types");
      Console.Write("\n -----------------------------------------------------------");
      Compare(s1, s1);
      Console.WriteLine();

      Console.Write("\n  Comparing equivalence tests for different reference types");
      Console.Write("\n -----------------------------------------------------------");
      Compare(s1, s2);
      Console.WriteLine();

      Console.Write("\n  Comparing equivalence tests for identical value types");
      Console.Write("\n -------------------------------------------------------");
      Compare(1, 1);
      Console.WriteLine();

      Console.Write("\n  Comparing equivalence tests for different value types");
      Console.Write("\n -------------------------------------------------------");
      Compare(1, 2);
      Console.WriteLine();

      Console.Write("\n  Comparing ReferenceEquals tests for identical reference types");
      Console.Write("\n ---------------------------------------------------------------");
      CompareReferenceEquals(s1, s1);
      Console.WriteLine();

      Console.Write("\n  Comparing ReferenceEquals tests for different reference types");
      Console.Write("\n ---------------------------------------------------------------");
      CompareReferenceEquals(s1, s2);
      Console.WriteLine();

      Console.Write("\n  Comparing ReferenceEquals tests for identical value types");
      Console.Write("\n -----------------------------------------------------------");
      CompareReferenceEquals(1, 1);
      Console.WriteLine();

      Console.Write("\n  Comparing ReferenceEquals tests for different value types");
      Console.Write("\n -----------------------------------------------------------");
      CompareReferenceEquals(1, 2);
      Console.Write("\n\n");
    }
  }
}
