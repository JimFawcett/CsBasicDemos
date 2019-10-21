///////////////////////////////////////////////////////////////
// Utilities.cs - Helpers for Linq Demos                     //
//                                                           //
// Jim Fawcett, CSE775 - Distributed Objects, Spring 2009    //
///////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CSE775
{
  public class Utilities
  {
    public static void title(string msg, char ch)
    {
      Console.Write("\n  {0}", msg);
      Console.Write("\n {0}", new String(ch, msg.Length + 2));
    }
    public static void title(string msg)
    {
      title(msg, '-');
    }
    public static void show<T>(IEnumerable<T> result)
    {
      Console.Write("\n  ");
      foreach (T t in result)
        Console.Write("{0} ", t.ToString());
      Console.Write("\n");
    }
    static void showXmlQueryResults(XDocument doc)
    {
      foreach (var anElem in doc.Descendants())
      {
        string valueField = null;
        var nodes = anElem.Nodes();
        if (nodes.Count() > 0)
        {
          foreach (var node in nodes)
            if (node.NodeType == XmlNodeType.Text)
              valueField = nodes.First().ToString();
        }
        if (anElem.Attributes().Count() > 0)
          Console.Write(
            "\n  {0,-12} {1}=\"{2}\" {3}",
            anElem.Name,
            anElem.Attributes().ElementAt(0).Name,
            anElem.Attributes().ElementAt(0).Value,
            valueField
          );
        else
          Console.Write(
            "\n  {0,-12} {1}",
            anElem.Name,
            valueField
          );
      }
      Console.Write("\n\n");
    }

    static void Main(string[] args)
    {
    }
  }
}
