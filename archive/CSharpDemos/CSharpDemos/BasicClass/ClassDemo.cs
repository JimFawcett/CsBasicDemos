///////////////////////////////////////////////////////////////////////
// ClassDemo.cs - Illustrate basic class operations                  //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, F2015       //
///////////////////////////////////////////////////////////////////////
/*
 * A class definition does three important things for you:
 *   1. Pulls together data and all the methods that directly manipulate
 *      it into one logical entity, making that code easier to understand.
 *   2. Protects its data from being changed by any other code and so
 *      ensuring that the class data always stays in a valid state.
 *   3. Allows using code to make multiple instances of the data, all 
 *      operated on by the same methods, while still ensuring protection
 *      of the data's integrity.
 */
/*
 * Read Chap 3 in the class text.
 */
using System;                             //     +--------+
using System.Collections.Generic;         //     | Object |
using System.Linq;                        //     +--------+
using System.Text;                        //          ^
using System.Threading.Tasks;             //          |
                                          //      +-------+
namespace CSharpDemos                     //      | Basic |
{                                         //      +-------+
  public class Basic
  {
    // class fields
    private double valueType_ = 3.1415927;
    private StringBuilder referenceType_ = new StringBuilder("a string");

    // class properties
    public double valueProperty { get; set; } = 3.2;
    public StringBuilder referenceProperty { get; set; } = 
      new StringBuilder("will be converted to StringBuilder");

    // constructor
    public Basic(double d=1.0/3, string s="default string")
    {
      this.valueProperty = d; 
      this.referenceProperty = new StringBuilder(s);
    }

    // destructor is really a finalizer, run by the garbage collector
    ~Basic()
    {
      Console.Write("\n  Basic instance is being finalized");
    }

    // member function
    public void showIdentity()
    {
      // "this" is a reference to the instance of the class that invoked method,
      // e.g., basic1 and basic2, below.  The code of each nonstatic member function
      // needs to identify which instance to act upon.

      Console.Write("\n  instance identity is {0}", this.GetHashCode());

      // GetHashCode() is a method inherited from the "Object" class from which all
      // reference types derive.
    }

    // member function
    public void showState()
    {
      showIdentity();
      Console.Write("\n          value field: {0}", valueType_);
      Console.Write("\n      reference field: {0}", referenceType_);
      Console.Write("\n       value property: {0}", valueProperty);
      Console.Write("\n   reference property: {0}", referenceProperty);
    }
  }
  // Extension methods are static methods of static classes that can be
  // applied to instances of the target type as if they were member functions.
  // They can't access private or protected member data of the target class
  // but can uses its public interface.

  static public class BasicExtensions  // the first argument type "this string" defines the target type
  {
    static public void title(this string astring, char underline = '-')
    {
      Console.Write("\n  {0}", astring);
      Console.Write("\n {0}", new string(underline, astring.Length + 2));
    }
  }

  class ClassDemo
  {
    static void Main(string[] args)
    {
      "Demonstrating Basic Class".title();

      Basic basic1 = new Basic();
      Type t = basic1.GetType();
      foreach (var method in t.GetMethods())
        Console.Write("\n  method: {0}", method);
      Console.WriteLine();

      "basic1 state".title();
      basic1.showState();
      Console.WriteLine();

      "basic2 state".title();
      Basic basic2 = new Basic(2.0/3, "another string");
      basic2.showState();
      Console.WriteLine();

      "\n  assigning reference types: basic2 = basic1".title();
      basic2 = basic1;

      BasicExtensions.title("now here are the resulting states");  // this works too
      "basic1 state".title();
      basic1.showState();
      Console.WriteLine();

      "basic2 state".title();
      basic2.showState();     // now basic1 and basic2 handles refer  to same object
      Console.Write("\n\n");
    }
  }
}
