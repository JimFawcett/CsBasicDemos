///////////////////////////////////////////////////////////////////////
///  TopReader.h - Declares class to read top few lines of          ///
///  ver 1.0       a specified file                                 ///
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
     TopReader* pTR = new TopReader();
     pTR->SetFile(fileName);
     pTR->ShowLines(15);

*/
/////////////////////////////////////////////////////////////////////// 
///  build process                                                  ///
///////////////////////////////////////////////////////////////////////
///  Required Files:                                                ///
///    TopReader.h, TopReader.cpp                                   ///
///  Compile Command:                                               ///
///    cl /DTEST_TOPREADER topReader.cpp                            ///
///  Run Command:                                                   ///
///    TopReader                                                    ///
///////////////////////////////////////////////////////////////////////
/*
     Maintenance History
     ===================
     ver 1.0 : 09/04/02
       - first release
        
*/
//
#pragma once
#using <mscorlib.dll>
using namespace System;
using namespace System::IO;

__gc class TopReader
{
private:
  StreamReader* pSR;

public:
  TopReader(void);
  ~TopReader(void);
  bool SetFile(String* fileName);
  void ShowLines(int numLines);
};
