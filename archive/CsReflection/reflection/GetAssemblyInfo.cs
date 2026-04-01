///////////////////////////////////////////////////////////////////////
///  GetAssemblyInfo.cs - extracts information from metadata        ///
///  ver 1.0                                                        ///
///                                                                 ///
///  Language:     Visual C++, ver 6.0                              ///
///  Platform:     Dell Dimension 8100, Windows Pro 2000, SP2       ///
///  Application:  CSE681 Example                                   ///
///  Author:       Jim Fawcett, CST 2-187, Syracuse Univ.           ///
///                (315) 443-3948, jfawcett@twcny.rr.com            ///
///////////////////////////////////////////////////////////////////////
/*
     Public Interface:
     -----------------
     AssemblyInfo ai = new AssemblyInfo(AssemName);
     Modules[] mods = ai.GetModules();
     string[] files = ai.GetFiles();
     string[] files = gf.files("../*.*");
     Types[]  types = ai.GetTypes();

*/
/////////////////////////////////////////////////////////////////////// 
///  build process                                                  ///
///////////////////////////////////////////////////////////////////////
///  Required Files:                                                ///
///    GetAssemblyInfo.cs                                           ///
///  Compile Command:                                               ///
///    csc /define:TEST_GETASSEMBLYINFO GetAssemblyInfo.cs          ///
///  Run Command:                                                   ///
///    GetAssemblyInfo demoFiles                                    ///
///////////////////////////////////////////////////////////////////////
/*
     Maintenance History
     ===================
     ver 1.0 : 09/01/02
       - first release
        
*/
//
using System;
using System.IO;
using System.Reflection;

namespace demoFiles
{
  public class AssemblyInfo
  {
    private Assembly _asm;

    //----< constructor loads assembly dll or exe >--------------------

    public AssemblyInfo(string AssemName)
    {
      try
      {
        _asm = Assembly.Load(AssemName);
      }
      catch
      {
        Console.WriteLine("\n  can't load assembly {0}\n\n",AssemName);
      }
    }
    //----< return array of Module Types with embedded info >----------

    public Module[] GetModules()
    {
      return _asm.GetModules(true);
    }
    //----< return array of string names of functions >----------------

    public string[] GetFiles()
    {
      FileStream[] fs = _asm.GetFiles(true);
      string[] fname = new string[fs.Length];
      for(int i=0; i<fs.Length; ++i)
      {
        fname[i] = fs[i].Name;
      }
      return fname;
    }
    //----< return array of Type objects with embedded info >----------

    public Type[] GetTypes()
    {
      return _asm.GetTypes();
    }
    //
#if(TEST_GETASSEMBLYINFO)

    //----< test stub >------------------------------------------------

    [STAThread]
    static void Main(string[] args)
    {
      Console.Write("\n  Testing GetAssemblyInfo Module ");
      Console.Write("\n ================================\n\n");

      AssemblyInfo ai = new AssemblyInfo("GetAssemblyInfo");
      Console.Write("\n  Searching for Modules in Assembly demoFiles ");
      Console.Write("\n ---------------------------------------------");
      Module[] modules = ai.GetModules();
      foreach(Module mod in modules)
      {
        Console.Write("\n    {0}",mod.Name);
      }
      Console.WriteLine();

      Console.Write("\n  Searching for files in Assembly demoFiles ");
      Console.Write("\n -------------------------------------------");
      string[] names = ai.GetFiles();
      foreach(string name in names)
      {
        Console.Write("\n    {0}",name);
      }
      Console.WriteLine("\n");
      
      Console.Write("\n  Searching for Types in Assembly demoFiles ");
      Console.Write("\n -------------------------------------------");
      Console.Write("\n    Full Name:");
      Type[] types = ai.GetTypes();
      foreach(Type type in types)
        Console.Write("\n    {0}",type.FullName);
      Console.WriteLine("\n");

      Console.Write("\n    Unqualified Name:");
      foreach(Type type in types)
        Console.Write("\n    {0}",type.Name);
      Console.WriteLine("\n");    }
#endif
  }
}
