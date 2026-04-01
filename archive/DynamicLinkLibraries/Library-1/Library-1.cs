///////////////////////////////////////////////////////////////////////
// Library1.cs - Demonstrate implicit and explicit loading           //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2006   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicLinkLibraries
{
  public class Library1 : ILib
  {
    public static ILib create() 
    { 
      return new Library1(); 
    }
    public Library1()
    {
      Console.Write("\n  Constructing {0}",this.GetType().Name);
    }
    public void say()
    {
      Console.Write("\n  hi from {0}", this.GetType().Name);
    }
  }

  public class Factory1 : absFactory
  {
    public new static ILib create() { return new Library1(); }
  }
}
