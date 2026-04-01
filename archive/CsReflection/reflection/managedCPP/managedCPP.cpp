///////////////////////////////////////////////////////////////////////
///  ManagedCPP.cpp - Demonstrates Managed C++ by reading           ///
///  ver 1.0          a few lines from a specified text file.       ///
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
     Simply execute and observe a demonstration of managed C++

*/
/////////////////////////////////////////////////////////////////////// 
///  build process                                                  ///
///////////////////////////////////////////////////////////////////////
///  Required Files:                                                ///
///    managedCPP.cpp, TopReader.h, TopReader.cpp                   ///
///  Compile Command:                                               ///
///    cl managedCPP.cpp TopReader.cpp                              ///
///  Run Command:                                                   ///
///    managedCPP TopReader.j ( or any other text file )            ///
///////////////////////////////////////////////////////////////////////
/*
     Maintenance History
     ===================
     ver 1.0 : 09/04/02
       - first release
        
*/
//

#include "stdafx.h"

#using <mscorlib.dll>
#include <tchar.h>
#include "TopReader.h"

using namespace System;

int _tmain(int argc, char* argv[])
{
  Console::Write(S"\n  Demonstrating Managed C++");
  Console::Write("\n ===========================\n\n");

  String* path = Path::GetFullPath(argv[1]);  // just reads the first arg
  TopReader* pTR = new TopReader();
  if(pTR->SetFile(path))
    pTR->ShowLines(20);
  else
    Console::WriteLine("\n  Could not open file {0}\n\n",path);
  Console::Write("\n\n");
  return 0;
}