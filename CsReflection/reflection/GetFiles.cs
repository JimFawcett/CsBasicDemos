///////////////////////////////////////////////////////////////////////
///  GetFiles.cs - finds files matching a specified path/pattern    ///
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
     GetFiles gf = new GetFiles();
     string[] files = gf.files("../*.*");
     gf.show();
*/
/////////////////////////////////////////////////////////////////////// 
///  build process                                                  ///
///////////////////////////////////////////////////////////////////////
///  Required Files:                                                ///
///    GetFiles.cs                                                  ///
///  Compile Command:                                               ///
///    csc /define:TEST_GETFILES GetFiles.cs                        ///
///  Run Command:                                                   ///
///    GetFiles *.*                                                 ///
///////////////////////////////////////////////////////////////////////
/*
     Maintenance History
     ===================
     ver 1.0 : 09/01/02
       - first release
        
*/
//
using System;       // Console, string
using System.IO;    // Path, Directory
using System.Reflection;

namespace demoFiles
{
  public class GetFiles
  {
    public GetFiles()
    {
    }
    
    //----< find files matching path/pattern, e.g., ..\*.h >-----------
    //
    //      returns fully qualified path
    //
    public string[] files(string pattern)
    {
      char[] pathSepChars = { '\\', '/' };
      int pos = pattern.LastIndexOfAny(pathSepChars);

      // extract path part
      //   could have used Path.GetDirectoryName(pattern);
      string path = pattern.Remove(pos+1,pattern.Length-pos-1);

      // convert to fully qualified path
      string targetDir;
      if(path.Length > 0)
        targetDir = Path.GetFullPath(path);
      else
        targetDir = Path.GetFullPath(".");

      // extract file pattern part
      //   could have used Path.GetFileName(pattern);
      string filePattern = pattern.Remove(0,pos+1);

      // now get files
      string[] files = Directory.GetFiles(targetDir,filePattern);
      return files;
    }
    //
    //----< display names of found files >-----------------------------

    public void show(string[] files, bool showTypes)
    {
      foreach(string file in files) 
      {
        Console.Write("\n    {0}",Path.GetFileName(file));
        if(showTypes)
        {
          string ext = Path.GetExtension(file);
          if(ext == ".cs" || ext == ".h" || ext == ".cpp")
          {
            string line;
            StreamReader tr = new StreamReader(file);
            while((line = tr.ReadLine()) != null)
            {
              if(line.IndexOf("class") > -1 || line.IndexOf("new") > -1)
              {
                string[] words = line.Split(null);
                for(int i=0; i<words.Length; ++i)
                {
                  if(words[i] == "class" && i < words.Length-1)
                  {
                    string temp = "      found declaration:   ";
                    Console.Write("\n{0}{1} {2}",temp,words[i],words[i+1]);
                    break;
                  }
                  else if(words[i] == "new" && i < words.Length-1)
                  {
                    string temp = "      found instantiation: ";
                    Console.Write("\n{0}{1} {2}",temp,words[i],words[i+1]);
                    break;
                  }
                }
              }
            }
          }
        }
      }
    }

#if(TEST_GETFILES)

    //----< test stub >------------------------------------------------

    [STAThread]
    static void Main(string[] args)
    {
      Console.Write("\n  Testing GetFiles Module ");
      Console.Write("\n =========================\n\n");

      GetFiles gf = new GetFiles();
      string[] files = gf.files("*.*");
      gf.show(files);
    }
#endif
  }
}
