/////////////////////////////////////////////////////////////
// disposing.cs - returning resources                      //
//                                                         //
// Jim Fawcett, CSE775 - Distributed Objects, Spring 2005  //
/////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Text;

namespace Disposing
{
  public class disposing
  {
    public static void Main()
    {
      StreamWriter StrmWr = new StreamWriter("Test.txt");
      StringBuilder sb = new StringBuilder();
      sb.Append("  a line of text");
      StringWriter StrgWr = new StringWriter(sb);

      using( StrgWr )
      {
        using( StrmWr )
        {
          StrmWr.WriteLine(sb.ToString());
          Console.WriteLine("  Disposing of {0}",StrmWr.GetType());  
        }
        StrgWr.Write(sb.ToString());
        Console.WriteLine(sb.ToString());
        Console.WriteLine("  Disposing of {0}",StrgWr.GetType());  
      }

      Console.WriteLine();
      sb.Remove(0,sb.Length);
      sb.Append("  another line of text");
      StrmWr = new StreamWriter("Test.txt");
      StrgWr = new StringWriter(sb);
      
      using( StrgWr )
      using( StrmWr )
      {
        StrmWr.WriteLine(sb.ToString());
        Console.WriteLine("  Disposing of {0}",StrmWr.GetType());  
        StrgWr.Write(sb.ToString());
        Console.WriteLine(sb.ToString());
        Console.WriteLine("  Disposing of {0}",StrgWr.GetType());  
      }
    }
  }
}
