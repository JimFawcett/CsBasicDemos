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
    public Library2()
    {
      Console.Write("\n  Constructing {0}",this.GetType().Name);
    }
    public void say()
    {
      Console.Write("\n  hi from {0}", this.GetType().Name);
    }
  }
}
