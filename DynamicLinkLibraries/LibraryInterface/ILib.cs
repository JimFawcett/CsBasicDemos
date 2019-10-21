///////////////////////////////////////////////////////////////////////
// ILib.cs - Interface shared by all demo libraries                  //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2006   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicLinkLibraries
{
  public interface ILib
  {
    void say();
  }

  public abstract class absFactory
  {
    public static ILib create() { return null; }
  }
}
