///////////////////////////////////////////////////////////////////////
///  TopReader.cpp - Implements class to read top few lines of      ///
///  ver 1.0         a specified file                               ///
///                                                                 ///
///  Language:     Visual C++, ver 6.0                              ///
///  Platform:     Dell Dimension 8100, Windows Pro 2000            ///
///  Application:  CSE681 Example                                   ///
///  Author:       Jim Fawcett, CST 2-187, Syracuse Univ.           ///
///                (315) 443-3948, jfawcett@twcny.rr.com            ///
///////////////////////////////////////////////////////////////////////

#include "StdAfx.h"
#include "topreader.h"

//----< constructor >--------------------------------------------------

TopReader::TopReader(void) : pSR(0)
{
}
//----< destructor >---------------------------------------------------

TopReader::~TopReader(void)
{
}
//----< define file to read >------------------------------------------

bool TopReader::SetFile(String* fileName)
{
  try {
    pSR = new StreamReader(fileName);
  }
  catch(...)
  {
    return false;
  }
  return true;
}
//----< read top few lines of file >-----------------------------------

void TopReader::ShowLines(int numLines)
{
  for(int i=0; i<numLines; i++)
  {
    String* temp = pSR->ReadLine();
    Console::Write("\n  {0}",temp);
  }
}
//----< test stub >----------------------------------------------------

#ifdef TEST_TOPREADER

void main()
{
  TopReader* pTR = new TopReader();
  pTR->SetFile("../managedCPP/TopReader.cpp");
  pTR->ShowLines(25);
}
#endif
