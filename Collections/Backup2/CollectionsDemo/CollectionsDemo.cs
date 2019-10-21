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
      Output outputFormatter = new Output();

      outputFormatter.MT("Demonstrating Use of Collections");
      outputFormatter.line();

      // create an array of strings
      outputFormatter.mT("using array of strings");
      string[] animals = { "zebra", "ardvaark", "elephant", "platypus" };
      outputFormatter.space(1);
      foreach(string animal in animals)
        outputFormatter.row(animal);
      outputFormatter.line().line();

      // sort animals array
      outputFormatter.mT("same stuff in sorted order");
      Array.Sort(animals);
      outputFormatter.space(1);
      foreach(string animal in animals)
        outputFormatter.row(animal);
      outputFormatter.line().line();

      outputFormatter.mT("using another module");
      DemoData d = new DemoData(animals);
      outputFormatter.mT("using SortedList container");
      d.SortedListDemo();
      outputFormatter.mT("using Hashtable container");
      d.HashTableDemo();
      outputFormatter.mT("using List<string> container");
      d.GenericListDemo();

      outputFormatter.line().line();
    }
  }
}
