/////////////////////////////////////////////////////////////////////
// ReflectionTestClass - Target for reflection analysis            //
//                                                                 //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2016 //
/////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UtilityExtensions;

namespace ReflectionDemos
{
  /////////////////////////////////////////////////////////////////
  // ReflectionTest class
  // - This class is used as a target for reflection analysis
  // - It has rich structure to show how reflection works
  //
  public class ReflectionTest
  {
    public delegate void SayHandler(string msg);
    public SayHandler sayHandler = null;
    public string name { get; set; }
    public ReflectionTest()
    {
      Console.Write("\n  constructing ReflectionTest instance");
      name = "Fawcett";
      sb_.Append("this is test class");
      if (sayHandler != null)
        sayHandler.Invoke("say function has been called");
    }
    ~ReflectionTest()
    {
      
    }
    public void say()
    {
      Console.Write("\n  {0}", sb_);
      Nested.say();
      if (sayHandler != null)
        sayHandler.Invoke(name + "'s say function has been called " + (++count).ToString() + " times");
    }
    public static void staticSay()
    {
      Console.Write("\n  staticSay has been called");
    }
    private int count = 0;
    private StringBuilder sb_ = new StringBuilder();
    class Nested
    {
      public static void say()
      {
        Console.Write("\n  hello from Nested.say()");
      }
    }
  }
  class Test_ReflectionTest_class
  {
    static void sayHandler(string msg)
    {
      Console.Write("\n  notification: {0}", msg);
    }
    static void Main(string[] args)
    {
      "Test ReflectionTest Class".title('=');
      Console.WriteLine();

      ReflectionTest rt = new ReflectionTest();
      rt.sayHandler += new ReflectionTest.SayHandler(Test_ReflectionTest_class.sayHandler);
      rt.say();
      rt.say();

      Console.Write("\n\n");
    }
  }
}
