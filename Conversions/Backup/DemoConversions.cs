/////////////////////////////////////////////////////////////////////////
// DemoConversions.cs - demonstrate simple string and type conversions //
//                                                                     //
// Jim Fawcett, CSE686 - Internet Programming, Summer 2003             //
/////////////////////////////////////////////////////////////////////////

using System;

namespace DemoConversions
{
  class DemoConverts
  {
    [STAThread]
    static void Main(string[] args)
    {
      Console.Write("\n  Demonstrate Conversions");
      Console.Write("\n =========================\n");

      // convert integer to string representing its value
      int i = 3;
      string si = i.ToString();
      
      // convert string to integer 
      string a = "2";
      int j = int.Parse(a);

      // convert char to integer
      char c = '1';
      int k = int.Parse(c.ToString());

      // convert string to double
      double d = double.Parse("3.1415927");

      // incorrect attempt to convert string to double
      // throws an exception
      try
      {
        double d2 = double.Parse("3.1415927 abc");
      }
      catch(Exception except)
      {
        string msg = "demonstrating handling of malformed string:\n  ";
        Console.Write("\n  {0}\n\n",msg+except.Message);
      }

      Console.Write("\n  Results using ToString() and Parse(): ");
      Console.Write("{0}, {1}, {2}, {3}\n\n",si,j,k,d);

      Console.Write("\n  Results using Convert class: ");
      i = Convert.ToInt32("3");
      Console.Write("{0}, ",i);

      d = Convert.ToDouble("3.5");
      Console.Write("{0}, ",d);

      bool b = Convert.ToBoolean("true");
      Console.Write("{0}\n\n",b);

    }
  }
}
