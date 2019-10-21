///////////////////////////////////////////////////////////////////////
///  CollectionsDemo.cs - Demonstrates use of collections           ///
///  ver 1.0                                                        ///
///                                                                 ///
///  Language:     Visual C#                                        ///
///  Platform:     Dell Dimension 8100, Windows Pro 2000, SP2       ///
///  Application:  CSE681 Example                                   ///
///  Author:       Jim Fawcett, CST 2-187, Syracuse Univ.           ///
///                (315) 443-3948, jfawcett@twcny.rr.com            ///
///////////////////////////////////////////////////////////////////////
/*
 *   Module Operations:
 *  ====================
 *   This module demonstrates two things:
 *   1. How to build a multi-module program.
 *   2. Use of .Net containers
 *   
 *   Creating a program from multiple modules is as easy as simply
 *   adding a new C# source file to the project.  The solution manager
 *   is smart enough to realize that the two files should be compiled
 *   and linked together to create a whole working program.
 * 
 *   In C# a module is a single source code file that has:
 *   1. Manual page:
 *      a. prologue
 *      b. module operations
 *      c. public interface description
 *   2. Maintenance page:
 *      a. Build Process
 *      b. Maintenance History.
 * 
 *   Public Interface:
 *  ===================
 *   This module is the executive, and so has only a user interface.  
 *   As a simple demonstration, it takes no command line arguments,
 *   so the only interface is to run it, e.g.:
 *     CollectionsDemo
 */
///////////////////////////////////////////////////////////////////////
/// Build Process                                                   ///
///////////////////////////////////////////////////////////////////////
/// Required Files:                                                 ///
///   CollectionsDemo.cs, DemoData.cs                               ///
///                                                                 ///
/// Compiler command:                                               ///
///   csc CollectionsDemo.cs DemoData.cs                            ///
///////////////////////////////////////////////////////////////////////   
// 
using System;

namespace DemoCollections
{
  class Collections
  {
    [STAThread]
    static void Main(string[] args)
    {
      Output o = new Output();

      o.MT("Demonstrating Use of Collections");
      o.line();

      // create an array of strings
      o.mT("using array of strings");
      string[] animals = { "zebra", "ardvaark", "elephant", "platypus" };
      o.space(1);
      foreach(string animal in animals)
        o.row(animal);
      o.line().line();

      // sort animals array
      o.mT("same stuff in sorted order");
      Array.Sort(animals);
      o.space(1);
      foreach(string animal in animals)
        o.row(animal);
      o.line().line();

      o.mT("using another module");
      DemoData d = new DemoData(animals);
      o.mT("using SortedList container");
      d.SortedListDemo();
      o.mT("using Hashtable container");
      d.HashTableDemo();

      o.line().line();
    }
  }
}
