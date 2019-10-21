///////////////////////////////////////////////////////////////////////
// Library2.cs - Demonstrate implicit and explicit loading           //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2006   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicLinkLibraries
{
  public class Library2 : ILib
  {
    public static ILib create()
    {
      return new Library2();
    }
    public Library2()
    {
      Console.Write("\n  Constructing {0}",this.GetType().Name);
    }
    public void say()
    {
      Console.Write("\n  hi from {0}", this.GetType().Name);
    }
  }

  public class Factory2 : absFactory
  {
    public static new ILib create() { return new Library2(); }
  }
}
