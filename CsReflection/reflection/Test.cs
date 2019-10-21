///////////////////////////////////////////////////////////////////////
///  Test.cs - Tests demoFiles Assembly                             ///
///  ver 1.0                                                        ///
///                                                                 ///
///  Language:     Visual C++, ver 6.0                              ///
///  Platform:     Dell Dimension 8100, Windows Pro 2000            ///
///  Application:  CSE681 Example                                   ///
///  Author:       Jim Fawcett, CST 2-187, Syracuse Univ.           ///
///                (315) 443-3948, jfawcett@twcny.rr.com            ///
///////////////////////////////////////////////////////////////////////
/*
     Public Interface:
     -----------------
     Simply execute and observe a list of tests for each module

*/
/////////////////////////////////////////////////////////////////////// 
///  build process                                                  ///
///////////////////////////////////////////////////////////////////////
///  Required Files:                                                ///
///    Test.cs, GetFiles.cs                                         ///
///  Compile Command:                                               ///
///    csc Test.cs GetFiles.cs                                      ///
///  Run Command:                                                   ///
///    Test *.*                                                     ///
///////////////////////////////////////////////////////////////////////
/*
     Maintenance History
     ===================
     ver 1.0 : 09/01/02
       - first release
        
*/
using System;
using System.IO;
using System.Reflection;

namespace demoFiles
{
  class Title
  {
    internal static void Major(string text)
    {
      Console.Write("\n  {0}",text);
      string temp = new string('=',text.Length+2);
      Console.Write("\n {0}",temp);
      Console.WriteLine();
    }
    internal static void Minor(string text)
    {
      Console.Write("\n  {0}",text);
      string temp = new string('-',text.Length+2);
      Console.Write("\n {0}",temp);
    }
  }
  //
  class Test
  {
    //----< test finding files matching some path and pattern string >-----

    internal static void Test_GetFiles(string[] args)
    {
      GetFiles gf = new GetFiles();
      foreach(string pattern in args)
      {
        string text = "Searching for files matching command line argument ";
        text += pattern;
        Title.Minor(text);
      
        // extract dir part of path
        string dir = Path.GetDirectoryName(pattern);
        string path;

        // get fully qualified path
        if(dir.Length > 0)
          path = Path.GetFullPath(dir);
        else
          path = Path.GetFullPath(".");
        Console.Write("\n  Path is: {0}",path);

        string[] files = gf.files(pattern);
        gf.show(files,true);
        Console.WriteLine();
      }
    }
    //----< test extraction of metadata >----------------------------------

    internal static void Test_GetAssemblyInfo(string AssemName)
    {
      AssemblyInfo ai = new AssemblyInfo(AssemName);

      Title.Minor("Searching for Modules in Assembly demoFiles");
      Module[] modules = ai.GetModules();
      foreach(Module mod in modules)
      {
        Console.Write("\n    {0}",mod.Name);
      }
      Console.WriteLine();

      Title.Minor("Searching for files in Assembly demoFiles");
      string[] names = ai.GetFiles();
      foreach(string name in names)
      {
        Console.Write("\n    {0}",name);
      }
      Console.WriteLine();
      
      Title.Minor("Searching for Types in Assembly demoFiles");
      Console.Write("\n    Full Name:");
      Type[] types = ai.GetTypes();
      foreach(Type type in types)
        Console.Write("\n    {0}",type.FullName);
      Console.WriteLine();

      Console.Write("\n    Unqualified Name:");
      foreach(Type type in types)
        Console.Write("\n    {0}",type.Name);
      Console.WriteLine("\n");
    }
    //
    //----< entry point >--------------------------------------------------

    [STAThread]
    static void Main(string[] args)
    {
      Title.Major("Testing demoFiles Assembly");

      if(args.Length == 0)
      {
        Console.WriteLine("\n  please enter path to directory to search\n");
        return;
      }
      Test_GetFiles(args);
      Test_GetAssemblyInfo("demoFiles");
    }
  }
}
