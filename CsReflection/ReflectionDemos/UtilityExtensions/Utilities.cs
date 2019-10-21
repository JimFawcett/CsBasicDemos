using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityExtensions
{
  public static class Utilities
  {
    public static void title(this string aString, char underline='-')
    {
      Console.Write("\n  {0}", aString);
      Console.Write("\n {0}", new string(underline, aString.Length + 2));
    }
    public static void write(this object obj, char terminator=' ')
    {
      Console.Write("{0}{1}", obj.ToString(), terminator);
    }
  }
  class Test_Utilities
  {
#if (TEST_UTILITIES)
    static void Main(string[] args)
    {
      "this is a title test".title();
      Console.Write("\n\n");
    }
  }
#endif
}
