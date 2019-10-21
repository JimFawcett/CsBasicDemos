///////////////////////////////////////////////////////////////////////
// DemoLoadingDlls.cs - Demonstrate implicit and explicit loading    //
// version 1.2                                                       //
//                                                                   //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2006   //
///////////////////////////////////////////////////////////////////////
/*
 * Why use Dynamic Link Libraries (DLLs)?  We use them for two reasons:
 * 1. If we find a defect in part of a large system, and if that part is
 *    packaged as a DLL, we don't need to rebuild the whole system.  Just
 *    fix the defect, and copy the new DLL into the system's load path.
 *    The new library will be implicitly loaded the next time the
 *    application starts.
 * 2. We want a system we are building to be extensible.  That is, we 
 *    want to add new functionality without changing, or even rebuilding
 *    the existing code.  We do this by defining a contract via an interface
 *    that all add-ins must impliment.  Extensible applications explicitly
 *    load libraries from some add-in path, create any needed instances, and
 *    use them.
 *    
 * This demo illustrates how to load Dynamic Link Libraries (DLLs, Libraries):
 * 1. Implicitly:
 *    Your code uses some type(s), defined in a DLL, but does not explicitly
 *    load that library.  The library is loaded by the CLR when its code
 *    is executed for the first time, e.g., a lazy load.  This is, by far,
 *    the most frequently used method.
 * 2. Explicitly:
 *    Your code uses some type(s), bound to an interface, staying blissfully
 *    ignorant of the concrete classes that are bound to the interface.
 *    Some part of the code has to load all libraries, create any instances
 *    that implement the interface, and use them as needed.
 * 
 * The code below should give you an idea of how that happens.
 * 
 * Note:
 *   You must build the projects (right-click on projects and select rebuild)
 *   in this order: 
 *   - LibraryInterface           - interface implemented by both libraries
 *   - Library-1 and Library-2    - the libraries that will be loaded
 *   - DynamicLinkLibraires       - the loader
 */
//
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace DynamicLinkLibraries
{
  class DemoLoadingDlls
  {
    static void Main(string[] args)
    {
      Console.Write("\n  Demonstrate Loading DLLs ");
      Console.Write("\n ==========================\n");

      Console.Write("\n  implicitly loading Libraries");
      Console.Write("\n ------------------------------\n");

      // Note that there is no code to load the library.  When the reference,
      // below is encountered, the library is automatically loaded from the
      // application's directory, or from a subdirectory.  If the subdirectory
      // has the name of the Library, then loading will happen automatically.
      // If it has some other name, we will need a configuration file:
      // ApplicationName.exe.config, that specifies where the assembly should
      // be loaded from.

      Console.Write("\n  Using creation with new:");
      Console.Write("\n --------------------------");

      Library1 lib1 = new Library1();
      lib1.say();
      Library2 lib2 = new Library2();
      lib2.say();
      Console.WriteLine();

      Console.Write("\n  Using factory creation so user doesn't need concrete type names:");
      Console.Write("\n ------------------------------------------------------------------");

      ILib lib1b = Factory1.create();
      lib1b.say();
      ILib lib2b = Factory2.create();
      lib2b.say();

      Console.Write("\n");

      //
      Console.Write("\n  explicitly loading Libraries");
      Console.Write("\n ------------------------------\n");

      // Use known Types from known Libraries
      //---------------------------------------------------------------
      // In the next few lines of code the library is explicitly loaded,
      // an instance of type Library1 is created and exercised.  
      
      // The code, below, uses hard-coded knowledge of library names and 
      // type names, as you see by studying the code.  This results in code 
      // that is likely to break if we make any changes.  We say that the 
      // code is brittle (easily broken).

      Console.Write("\n  Construct instances and invoke their members");
      Console.Write(
        "\n  using specific knowledge of library and type names:"
      );
      Console.Write("\n -----------------------------------------------------");

      Assembly assem = Assembly.LoadFrom("Library-1.dll");
      ILib libr = Library1.create();
      lib1.say();
      assem = Assembly.LoadFrom("Library-2.dll");
      libr = Library2.create();
      libr.say();

      //
      // Discover Libraries and Types that implement a known Interface
      //---------------------------------------------------------------
      // In the next set of code lines, we explicitly load all assemblies
      // from some directory, and create instances of all types that 
      // implement a specific interface, and then make calls on the
      // interface methods.  

      // We don't use any knowledge of the specific libraries and types
      // contained in them.  We say that we have loosely coupled to the
      // code in those libraries.

      Console.WriteLine();
      Console.Write("\n  Construct instances and invoke their members using knowledge of interface");
      Console.Write(
        "\n  type, but no prior knowledge of library  or type names, through reflection:"
      );
      Console.Write("\n -----------------------------------------------------------------------------");

      string path 
        = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
      string[] Libraries = Directory.GetFiles(path, "*.dll");
      foreach (string library in Libraries)
      {
        assem = Assembly.LoadFrom(library);
        Type[] types = assem.GetExportedTypes();
        foreach (Type t in types)
        {
          // Using the interface

          ILib lib = null;
          if (t.IsClass && typeof(ILib).IsAssignableFrom(t))
            lib = (ILib)Activator.CreateInstance(t);
          else
            continue;
          lib.say();

          ///////////////////////////////////////////////////////////
          //// This works, but requires we know the Factory names
          //
          //  ILib lib = null;
          //  if (t.IsClass && typeof(absFactory).IsAssignableFrom(t))
          //  {
          //    // attempt to use static create function
          //
          //    if (t.Name == "Factory1")
          //      lib = Factory1.create();
          //    else if (t.Name == "Factory2")
          //      lib = Factory2.create();
          //    else
          //      continue;
          //    lib.say();
          //  }
        }
      }

      // Note:
      //-------
      // This is one of two methods of using DLLs recommended for Projects
      // you will implement in CSE681 and CSE784.  The other is implicit
      // loading.

      //
      // Discover Libraries, Types, and Methods using Reflection
      //---------------------------------------------------------
      // In this last set of code, we load all available libraries from
      // a specified path, construct instances of all classes defined within
      // and discover, using reflection, the names of all their methods.
      // Then we call all methods that have no arguments, using dynamic
      // invocation.
      
      // Note that we could, using reflection, find the types and order of 
      // all parameters of each function, but it is unlikely that we would 
      // know what values to supply.  For that reason, we stick to the
      // simpler scenario of parameterless methods.

      Console.WriteLine();
      Console.Write("\n  Construct instances and invoke their members using no");
      Console.Write("\n  prior knowledge, via dynamic invocation and reflection:"
      );
      Console.Write("\n ---------------------------------------------------------");

      foreach (string library in Libraries)
      {
        assem = Assembly.LoadFrom(library);
        Type[] types = assem.GetExportedTypes();
        foreach (Type t in types)
        {
          if (t.IsClass && !t.IsAbstract)
          {
            object obj = Activator.CreateInstance(t);
            MethodInfo[] mis = t.GetMethods();
            foreach (MethodInfo mi in mis)
            {
              // don't call base members

              if (mi.DeclaringType != typeof(object))
              {
                // don't call if method has arguments
                try
                {
                  if (mi.GetParameters().Length == 0/* && mi.Name != "create"*/)
                  {
                    const BindingFlags bf =
                      BindingFlags.Public |
                      BindingFlags.InvokeMethod |
                      BindingFlags.Instance;
                    t.InvokeMember(mi.Name, bf, null, obj, null);
                  }
                }
                catch { /* continue on error - calling factory function create throws */ }
              }
            }
          }
        }
      }
      Console.Write("\n\n");
    }
  }
}
