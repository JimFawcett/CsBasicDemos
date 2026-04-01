using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
  public static class Utilities
  {
    public static void title(this string aString, char underline='-')
    {
      Console.Write("\n  {0}", aString);
      Console.Write("\n {0}", new string(underline, aString.Length + 2));
    }
    static void Main(string[] args)
    {
    }
  }
}
