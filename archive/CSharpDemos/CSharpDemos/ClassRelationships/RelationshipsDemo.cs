///////////////////////////////////////////////////////////////////////////
// RelationshipsDemo.cs - Illustrate class relationships:                //
//                        Inheritance, composition, aggregation, using   //
//                                                                       //       +---+       +-----+      +---+
// Jim Fawcett, CSE681 - Software Modeling and Analysis, F2015           //       | C |----<@>|  B  |<>----| A |
///////////////////////////////////////////////////////////////////////////       +---+       +-----+      +---+
/*                                                                                               ^
 * The four class relationships are surprisingly complete modeling tools:                        |
 *   1. Inheritance models specialization in an "is-a" relationship.                          +-----+     +---+
 *   2. Composition is a strong form of ownership.  A composed instance is                    |  D  |---->| U |
 *      is an integral part of the owner with the same lifetime.                              +-----+     +---+
 *      Only value types can be composed.
 *   3. Aggregation is a weaker form of ownership that is not intrinsic to
 *      the owner.  The Aggregated might never by created. Reference types
 *      can only be aggregated.
 *   4. A using class is passed the used type as a method parameter and is
 *      not owned by the user.  Both value and reference types may be used.
 */
/*
 * NOTE: This package adds a reference to the DemoExtensions project so
 *       that code here can use extension methods defined in that project.
 *
 *       References are added by right-clicking on the References node
 *       in Solution Explorer for the using project and selecting
 *       "Add Reference" then picking the appropriate project in the popup
 *       dialog.
 */
/*
 * Read Chap 3 in the class text.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemos
{
  ///////////////////////////////////////////////////////////////////////
  //// helper class BasicExtensions extends strings with title method
  ////
  //static public class BasicExtensions  // the first argument type "this string" defines the target type
  //{
  //  static public void title(this string astring, char underline = '-')
  //  {
  //    Console.Write("\n  {0}", astring);
  //    Console.Write("\n {0}", new string(underline, astring.Length + 2));
  //  }
  //  static public void showMethods(this object anObject)
  //  {
  //    Type t = anObject.GetType();
  //    foreach (var method in t.GetMethods())
  //      Console.Write("\n  method: {0}", method);
  //  }
  //}

  /////////////////////////////////////////////////////////////////////
  // helper class ShowType uses reflection to detect kind of instance
  //
  public static class showType
  {
    public static string eval<R>(R r)
    {
      Type t = r.GetType();
      if (t.IsValueType)
        return "is value type";
      return "is reference type";
    }
  }
  /////////////////////////////////////////////////////////////////////
  // struct C will be composed by class B
  //
  public struct C
  {
    public int var1;
    public double var2;
    public string var3;
    public void say()
    {
      Console.Write("\n  C here.  My value is: [{0}, {1}, \"{2}\"]", var1, var2, var3);
      Console.Write("\n  C {0}", showType.eval(this));

    }
  }
  /////////////////////////////////////////////////////////////////////
  // struct U will be used by class D
  //
  public struct U
  {
    public int var1;
    public double var2;
    public string var3;
    public U(int arg1, double arg2, string arg3)
    {
      Console.Write("\n  U Constructed");
      var1 = arg1;
      var2 = arg2;
      var3 = arg3;
    }
    public void say()
    {
      Console.Write("\n  U here.  My value is: [{0}, {1}, \"{2}\"]", var1, var2, var3);
      Console.Write("\n  U {0}", showType.eval(this));
    }
  }
  /////////////////////////////////////////////////////////////////////
  // class A will be aggregated by class B
  //
  public class A
  {
    public A() { Console.Write("\n  A Constructed"); }
    ~A() { Console.Write("\n  A destroyed"); }
    public void say()
    {
      Console.Write("\n  A here");
      Console.Write("\n  A {0}", showType.eval(this));
    }
  }
  /////////////////////////////////////////////////////////////////////
  // class B is the Base from which D inherits
  //
  public class B
  {
    private A a;  // aggregated
    private C c;  // composed
    public B()
    {
      Console.Write("\n  B Constructed");
      a = new A();   // here's were aggregation occurs
        // note that c is constructed by default which 
        // does default initialization on each member
    }
    public virtual void say()
    {
      Console.Write("\n  B here, composing C");
      Console.Write("\n  B {0}", showType.eval(this));
      a.say();
      c.say();
    }
    ~B() { Console.Write("\n  B destroyed"); }
  }
  /////////////////////////////////////////////////////////////////////
  // class D derives from class B and is a specialization of B
  //
  public class D : B  // only public inheritance is defined
  {
    public D() { Console.Write("\n  D constructed"); }
    ~D() { Console.Write("\n  D destroyed"); }
    public override void say()
    {
      Console.Write("\n  D here, derived from B");
      Console.Write("\n  D {0}", showType.eval(this));
      base.say();
    }
    public void use(U u)
    {
      Console.Write("\n  D using U[{0}, {1}, {2}]", u.var1, u.var2, u.var3);
      Console.Write("\n  U {0}", showType.eval(u));
    }
  }
  /////////////////////////////////////////////////////////////////////
  // class RelationshipDemos orchestrates the demonstration
  //
  class RelationshipsDemo
  {
    static void Main(string[] args)
    {
      "Demonstrating Class Relationships".title('=');

      "\n  Constructing B".title();
      B b = new B();

      "\n  methods of B are:".title();
      b.showMethods();

      "\n  Constructing D".title();
      D d = new D();

      "\n  methods of D are:".title();
      d.showMethods();

      "\n  invoking d.say()".title();
      d.say();

      "\n  Constructing u1".title();
      U u1 = new U(1, 2.0, "three");

      "\n  d.use(u1)".title();
      d.use(u1);

      "\n  constructing u2".title();
      U u2;
      u2.var1 = -1;
      u2.var2 = -2;
      u2.var3 = "minus three";

      "\n  d.use(u2)".title();
      d.use(u2);
      Console.Write("\n\n");
    }
  }
}
