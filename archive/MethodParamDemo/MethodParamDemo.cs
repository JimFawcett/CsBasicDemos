///////////////////////////////////////////////////////////////////////////
// MethodParamDemo.cs - Demonstrate Call by value and Call be reference  //
//                                                                       //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2004       //
///////////////////////////////////////////////////////////////////////////

using System;
using System.Text;

namespace MethodParamDemo
{
  class first { }
  class second { }
  class ParamDemo
  {
    //----< pass value type by value >-------------------------

    void intValueParams(int xv, int yv)
    {
      Console.Write("\n  values passed to intValueParams:");
      Console.Write("\n  xv = {0}, yv = {1}",xv,yv);
      int temp = xv;
      xv = yv;
      yv = temp;
      Console.Write("\n  values after swapping:");
      Console.Write("\n  xv = {0}, yv = {1}",xv,yv);
      yv = -yv;
      Console.Write("\n  values after modifying yv:");
      Console.Write("\n  xv = {0}, yv = {1}",xv,yv);
    }
    //----< pass value type by reference >---------------------

    void intRefParams(ref int xr, ref int yr)
    {
      Console.Write("\n  values passed to intRefParams:");
      Console.Write("\n  xr = {0}, yr = {1}",xr,yr);
      int temp = xr;
      xr = yr;
      yr = temp;
      Console.Write("\n  values after swapping:");
      Console.Write("\n  xr = {0}, yr = {1}",xr,yr);
      yr = -yr;
      Console.Write("\n  values after modifying yr:");
      Console.Write("\n  xr = {0}, yr = {1}",xr,yr);
    }
    //
    //----< pass reference type by value >---------------------

    void StringBuilderValueParams(StringBuilder sv, StringBuilder tv)
    {
      Console.Write("\n  values passed to StringBuilderValueParams:");
      Console.Write("\n  sv = {0}, tv = {1}",sv,tv);
      StringBuilder temp = sv;
      sv = tv;
      tv = temp;
      Console.Write("\n  values after swapping:");
      Console.Write("\n  sv = {0}, tv = {1}",sv,tv);
      tv.Append(" and more stuff");
      Console.Write("\n  values after modifying tv:");
      Console.Write("\n  sv = {0}, tv = {1}",sv,tv);
    }
    //----< pass reference type by reference >-----------------

    void StringBuilderRefParams(ref StringBuilder sr, ref StringBuilder tr)
    {
      Console.Write("\n  values passed to StringBuilderRefParams:");
      Console.Write("\n  sr = {0}, tr = {1}",sr,tr);
      StringBuilder temp = sr;
      sr = tr;
      tr = temp;
      Console.Write("\n  values after swapping:");
      Console.Write("\n  sr = {0}, tr = {1}",sr,tr);
      tr.Append(" and more stuff");
      Console.Write("\n  values after modifying tr:");
      Console.Write("\n  sr = {0}, tr = {1}",sr,tr);
    }
    //----< pass user defined type by value >------------------

    void ObjectValueParams(object ov, object pv)
    {
      Console.Write("\n  values passed to ObjectValueParams:");
      Console.Write("\n  ov = {0}, pv = {1}",ov.ToString(),pv.ToString());
      object temp = ov;
      ov = pv;
      pv = temp;
      Console.Write("\n  values after swapping:");
      Console.Write("\n  ov = {0}, pv = {1}",ov.ToString(),pv.ToString());
    }
    //----< pass user defined type by reference >--------------

    void ObjectRefParams(ref object or, ref object pr)
    {
      Console.Write("\n  values passed to ObjectRefParams:");
      Console.Write("\n  or = {0}, pr = {1}",or.ToString(),pr.ToString());
      object temp = or;
      or = pr;
      pr = temp;
      Console.Write("\n  values after swapping:");
      Console.Write("\n  or = {0}, pr = {1}",or.ToString(),pr.ToString());
    }
    //
    //----< Test parameter passing >---------------------------

    [STAThread]
    static void Main(string[] args)
    {
      Console.Write("\n  Method Calls Demo");
      Console.Write("\n ===================\n");

      ParamDemo pd = new ParamDemo();
      int xv=2, yv=3;
      pd.intValueParams(xv,yv);
      Console.Write("\n  values after returning:");
      Console.Write("\n  xv = {0}, yv = {1}",xv,yv);
      Console.Write("\n\n");

      int xr=2, yr=3;
      pd.intRefParams(ref xr, ref yr);
      Console.Write("\n  values after returning:");
      Console.Write("\n  xr = {0}, yr = {1}",xr,yr);
      Console.Write("\n\n");

      StringBuilder sv = new StringBuilder("string sv");
      StringBuilder tv = new StringBuilder("string tv");
      pd.StringBuilderValueParams(sv, tv);
      Console.Write("\n  values after returning:");
      Console.Write("\n  sv = {0}, tv = {1}",sv,tv);
      Console.Write("\n\n");

      StringBuilder sr = new StringBuilder("string sr");
      StringBuilder tr = new StringBuilder("string tr");
      pd.StringBuilderRefParams(ref sr, ref tr);
      Console.Write("\n  values after returning:");
      Console.Write("\n  sr = {0}, tr = {1}",sr,tr);
      Console.Write("\n\n");

      first ov = new first();
      second pv = new second();
      pd.ObjectValueParams(ov,pv);
      Console.Write("\n  values after returning:");
      Console.Write("\n  ov = {0}, pv = {1}",ov.ToString(),pv.ToString());
      Console.Write("\n\n");

      object or = new first();
      object pr = new second();
      pd.ObjectRefParams(ref or, ref pr);
      Console.Write("\n  values after returning:");
      Console.Write("\n  or = {0}, pr = {1}",or.ToString(),pr.ToString());
      Console.Write("\n\n");
    }
  }
}
