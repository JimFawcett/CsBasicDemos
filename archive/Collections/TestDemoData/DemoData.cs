///////////////////////////////////////////////////////////////////////
///  DemoData.cs - demonstrates creation of a second module         ///
///  ver 1.0       using HashTable and SortedList collections       ///
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
 *   This module is part of the CollectionsDemo program.  It demonstrates 
 *   use of .Net containers SortedList and HashTable.
 *   
 *   Public Interface:
 *  ===================
 *   DemoData provides a constructor and two public functions:
 *     string[] strArray = { "one", "two", "three" };
 *     DemoData dem = new DemoData(StrArray);
 *     dem.HashTableDemo();
 *     dem.SortedListDemo();
 *     
 */
///////////////////////////////////////////////////////////////////////
/// Build Process                                                   ///
///////////////////////////////////////////////////////////////////////
/// Required Files:                                                 ///
///   DemoData.cs                                                   ///
///                                                                 ///
/// Compiler command:                                               ///
///   csc DemoData.cs                                               ///
///////////////////////////////////////////////////////////////////////   
 
using System;
using System.Collections;
using System.IO;

namespace DemoCollections
{
  internal class Output
  {
    internal void MT(string msg)
    {
      Console.Write("\n  {0}",msg);
      string underline = new string('=',msg.Length+2);
      Console.Write("\n {0}\n",underline);
    }
    internal void mT(string msg)
    {
      Console.Write("\n  {0}",msg);
      string underline = new string('-',msg.Length+2);
      Console.Write("\n {0}\n",underline);
    }
    internal Output()
    {
    }
    internal Output col(string msg)
    {
      Console.Write("\n  {0}",msg);
      return this;
    }
    internal Output col(string msg,int n)
    {
      string format = "\n{0,";
      format += n.ToString() + "}";
      Console.Write(format,msg);
      return this;
    }
    internal Output row(string msg)
    {
      Console.Write(" {0}",msg);
      return this;
    }
    internal Output row(string msg, int n)
    {
      string format = "{0,";
      format += n.ToString() + "}";
      Console.Write(format,msg);
      return this;
    }
    internal Output str(string msg)
    {
      Console.Write(msg);
      return this;
    }
    //
    internal Output line()
    {
      Console.WriteLine();
      return this;
    }
    internal Output space(int n)
    {
      string spaces = new String(' ',n);
      Console.Write(spaces);
      return this;
    }
  }
  //----< constructor demonstrates passing data between classes >------

  public class DemoData
  {
    private string[] input;
    public DemoData(string[] inputData)
    {
      Output o = new Output();
      input = inputData;
      o.space(1).row("data sent from Class1:");
      foreach(string datum in input)
        o.row(datum);
      o.line().line();
    }
    //----< Hashtables provide fast lookup in large collections >------

    public void HashTableDemo()
    {
      try
      {
        Hashtable table = new Hashtable();
        int size = 0;
        string file = "../../DemoData.cs";
        StreamReader fs = new StreamReader(file);
        string line;
        while((line = fs.ReadLine()) != null)
        {
          string[] tokens = line.Split();
          foreach(string token in tokens)
          {
            if(table.Contains(token))
              table[token] = 1 + (int)table[token];
            else
            {
              table[token] = 1;
              ++size;
            }
          }
        }
        Output o = new Output();
        o.col("There are ").str(size.ToString());
        o.str(" unique tokens in file ").str(file);
        o.col("The keyword \"class\" occurs ");
        o.str(table["class"].ToString()).str(" times.");
        o.col("The keyword \"public\" occurs ");
        o.str(table["public"].ToString()).str(" times.");
        o.line();
      }
      catch(Exception e)
      {
        Console.Write("\n  {0}\n\n",e.Message);
      }
    }
    //----< SortedLists are like std C++ maps >------------------------

    public void SortedListDemo()
    {
      // use SortedList - a dictionary with sorted keys
      SortedList sl = new SortedList();
      sl["horse"] = "A four-legged, not very bright, beast of burden";
      sl["cheeta"] 
        = "a sleek, spotted, and very fast member of the feline family";
      sl["skunk"] = "An odoriforous black and white mammal";
      sl["bat"] = "a flying mammal that uses sound as a navigation device";

      Output o = new Output();
      foreach(string k in sl.GetKeyList())
      {
        o.col("").row(k,-7).str(": ");
        o.row(sl[k].ToString()).line();
      }
      o.line();
    }
#if(TEST_DEMODATA)
    
    [STAThread]
    static void Main(string[] args)
    {
      Console.Write("\n  Testing DemoData Module\n");

      // create an array of strings
      string[] animals = { "zebra", "ardvaark", "elephant", "platypus" };
      foreach(string animal in animals)
        Console.Write("\n  {0}",animal);

      // sort animals array
      Array.Sort(animals);
      foreach(string animal in animals)
        Console.Write("\n  {0}",animal);

      DemoData d = new DemoData(animals);
      Console.Write("\n\n  demonstrating SortedList\n");
      d.SortedListDemo();
      Console.Write("\n\n  demonstrating HashTable\n");
      d.HashTableDemo();
      Console.Write("\n\n");
    }
#endif
  }
}
