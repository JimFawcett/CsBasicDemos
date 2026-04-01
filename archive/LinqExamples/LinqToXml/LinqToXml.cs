///////////////////////////////////////////////////////////////
// LinqToXml.cs - Demonstrate Linq Queries on XML documents  //
//                                                           //
// Jim Fawcett, CSE775 - Distributed Objects, Spring 2009    //
///////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

namespace CSE775
{
  class LinqToXml
  {
    static void Main(string[] args)
    {
      Utilities.title("Demonstrate Linq to XML", '=');

      Utilities.title("Loading XML from \"LectureNote.xml\"");
      Console.WriteLine();
      XDocument doc = XDocument.Load(@"..\..\LectureNote.xml");
      Console.Write(doc.ToString());
      Console.Write("\n\n");

      Utilities.title("Names of Descendents of \"reference\"");
      var q = from x in 
                doc.Elements("LectureNote")
                .Elements("reference")
                .Descendants()
              select x;

      foreach (var elem in q)
        Console.Write("\n  {0}", elem.Name);
      Console.Write("\n\n");

      Utilities.title("Names and Values of Children of \"reference\"");
      q = from x in
            doc.Elements("LectureNote")
            .Elements("reference")
            .Elements()
          select x;

      foreach (var elem in q)
        Console.Write("\n  {0,-12} {1}", elem.Name, elem.Value);
      Console.Write("\n\n");

      Utilities.title("Decendents' Names and Values where Name==\"title\"");
      q = from x in
            doc.Descendants()
          where (x.Name == "title")
          select x;

      foreach (var elem in q)
        Console.Write("\n  {0,-12} {1}", elem.Name, elem.Value);
      Console.Write("\n\n");

      Utilities.title("Names and Attributes of Decendents' with Attributes");
      q = from x in
            doc.Descendants()
          where (x.Attributes().Count() > 0)
          select x;

      foreach (var elem in q)
        Console.Write(
          "\n  {0,-12} {1}=\"{2}\"",
          elem.Name,
          elem.Attributes().ElementAt(0).Name,
          elem.Attributes().ElementAt(0).Value
        );
      Console.Write("\n\n");

      Utilities.title("Add new Element \"newElement\"");

      XElement el = doc.Descendants("reference").First();

      XElement newElem = new XElement("newElement");
      newElem.Value = "a body of text";
      el.Add(newElem);

      string result = doc.ToString();
      Console.Write(result);
      Console.Write("\n\n");

      Utilities.title("Remove Element \"title\"");
      Console.WriteLine();
      el.Element("title").Remove();
      result = doc.ToString();
      Console.Write(result);

      doc.Save("newLectureNote.xml");
      Console.Write("\n\n  saved to \"newLectureNote.xml\"\n\n");

      q = from x in
            doc.Elements("LectureNote")
            .Elements("reference")
            .Descendants()
          select x;

      Utilities.title("Convert Query to List");
      var lst = q.ToList();
      foreach (var item in lst)
        Console.Write("\n  {0}", item.Name);
      Console.Write("\n\n");

      Utilities.title("Build an XML Document");
      Console.WriteLine();
      XDocument xml = new XDocument(
        new XDeclaration("1.0", "utf-8", "yes"),
        new XComment("comment about this document"),
        new XElement("root",
          new XElement("first_child", new XAttribute("Id", "e1"), "a child"),
          new XElement("second_child",
            new XElement("first_grandchild", "fgc body"),
            new XElement("second_grandchild")
          ),
          new XElement("third_child")
        )
      );
      xml.Save("xmlDoc.xml");
      Console.Write(xml.ToString());
      Console.Write("\n\n");

      ////////////////////////////////////////////////////////////
      // This last part is incomplete
      //
      //   Utilities.title("Binding XML to Object");
      //   Console.WriteLine(); 
      //   var person = new { First = "Jim", Second = "Fawcett" };
      //   Console.Write(person.ToString());
      //   Console.Write("\n\n");
    }
  }
}
