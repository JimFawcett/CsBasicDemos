///////////////////////////////////////////////////////////////////////////////
// THMessages.cs - Demonstrate XML Serializer on TestHarnes Data Structures  //
//                                                                           //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2016           //
///////////////////////////////////////////////////////////////////////////////
/*
 * Demonstrates serializing and deserializing complex data structures used
 * in TestHarnes.
 * 
 * This demo serializes and deserializes TestRequest and TestResults instances.
 * It then Creates and parses a TestRequest Message and a TestResults Message,
 * retrieving copies of the original data structures.
 * 
 * The purpose of this demo is to show that using a single message class with
 * an XML body is a reasonable alternative for message passing in Project #4. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using TestHarness;
using Utilities;

namespace TestHarnessMessages
{
  ///////////////////////////////////////////////////////////////////
  // TestElement and TestRequest classes
  //
  public class TestElement  /* information about a single test */
  {
    public string testName { get; set; }
    public string testDriver { get; set; }
    public List<string> testCodes { get; set; } = new List<string>();

    public TestElement() { }
    public TestElement(string name)
    {
      testName = name;
    }
    public void addDriver(string name)
    {
      testDriver = name;
    }
    public void addCode(string name)
    {
      testCodes.Add(name);
    }
    public override string ToString()
    {
      string temp = "\n    test: " + testName;
      temp += "\n      testDriver: " + testDriver;
      foreach (string testCode in testCodes)
        temp += "\n      testCode:   " + testCode;
      return temp;
    }
  }

  public class TestRequest  /* a container for one or more TestElements */
  {
    public string author { get; set; }
    public List<TestElement> tests { get; set; } = new List<TestElement>();

    public TestRequest() { }
    public TestRequest(string auth)
    {
      author = auth;
    }
    public override string ToString()
    {
      string temp = "\n  author: " + author;
      foreach (TestElement te in tests)
        temp += te.ToString();
      return temp;
    }
  }
  ///////////////////////////////////////////////////////////////////
  // TestResult and TestResults classes
  //
  public class TestResult  /* information about processing of a single test */
  {
    public string testName { get; set; }
    public bool passed { get; set; }
    public string log { get; set; }

    public TestResult() { }
    public TestResult(string name, bool status)
    {
      testName = name;
      passed = status;
    }
    public void addLog(string logItem)
    {
      log += logItem;
    }
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("\n    Test: " + testName + " " + passed);
      sb.Append("\n    log:  " + log);
      return sb.ToString();
    }
  }

  public class TestResults  /* a container for one or more TestResult instances */
  {
    public string author { get; set; }
    public DateTime timeStamp { get; set; }
    public List<TestResult> results { get; set; } = new List<TestResult>();

    public TestResults() { }
    public TestResults(string auth, DateTime ts)
    {
      author = auth;
      timeStamp = ts;
    }
    public TestResults add(TestResult rslt)
    {
      results.Add(rslt);
      return this;
    }
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("\n  Author: " + author + " " + timeStamp.ToString());
      foreach (TestResult rslt in results)
      {
        sb.Append(rslt.ToString());
      }
      return sb.ToString();
    }
  }

  //----< test stub >------------------------------------------------

#if (TEST_THMESSAGES)

  class TestTHMessages
  {
    static void Main(string[] args)
    {
      "Testing THMessage Class".title('=');
      Console.WriteLine();

      ///////////////////////////////////////////////////////////////
      // Serialize and Deserialize TestRequest data structure

      "Testing Serialization of TestRequest data structure".title();

      TestElement te1 = new TestElement();
      te1.testName = "test1";
      te1.addDriver("td1.dll");
      te1.addCode("tc1.dll");
      te1.addCode("tc2.dll");

      TestElement te2 = new TestElement();
      te2.testName = "test2";
      te2.addDriver("td2.dll");
      te2.addCode("tc3.dll");
      te2.addCode("tc4.dll");

      TestRequest tr = new TestRequest();
      tr.author = "Jim Fawcett";
      tr.tests.Add(te1);
      tr.tests.Add(te2);
      string trXml = tr.ToXml();
      Console.Write("\n  Serialized TestRequest data structure:\n\n  {0}\n", trXml);

      "Testing Deserialization of TestRequest from XML".title();

      TestRequest newRequest = trXml.FromXml<TestRequest>();
      string typeName = newRequest.GetType().Name;
      Console.Write("\n  deserializing xml string results in type: {0}\n", typeName);
      Console.Write(newRequest);
      Console.WriteLine();

      ///////////////////////////////////////////////////////////////
      // Create and Parse TestRequest message

      "Testing Creation and Parsing of TestRequest Message".title();

      Message msg = new Message();
      msg.to = "TH";
      msg.from = "CL";
      msg.type = "basic";
      msg.author = "Fawcett";

      Console.Write("\n  base message:\n    {0}", msg.ToString());
      msg.show();

      Console.Write("\n  Creating Message using TestRequest data structure\n");
      Message rqstMsg = new Message();
      rqstMsg.author = "Fawcett";
      rqstMsg.to = "TH";
      rqstMsg.from = "CL";
      rqstMsg.type = "TestRequest";
      rqstMsg.time = DateTime.Now;
      rqstMsg.body = tr.ToXml();
      rqstMsg.show();

      Console.Write("\n  retrieving testRequest object:");
      TestRequest newTrq = rqstMsg.body.FromXml<TestRequest>();
      Console.Write("\n{0}\n", newTrq);

      ///////////////////////////////////////////////////////////////
      // Serialize and Deserialize TestResults data structure

      "Testing Serialization of TestResults data structure".title();

      TestResult tr1 = new TestResult();
      tr1.testName = "test1";
      tr1.passed = true;
      tr1.log = "test always passes";

      TestResult tr2 = new TestResult("test2", false);
      tr2.addLog("test always fails");
      tr2.addLog(" every time");
      TestResults rslts = new TestResults("Fawcett", DateTime.Now);
      rslts.add(tr1).add(tr2);

      // using extension method syntax

      string xml = rslts.ToXml();
      Console.Write("\n  Serialized TestResults data structure:\n\n  {0}\n", xml);

      "Testing Deserialization of TestResults from XML".title();

      TestResults newResults = xml.FromXml<TestResults>();
      typeName = newResults.GetType().Name;
      Console.Write("\n  deserializing xml string results in type: {0}\n", typeName);
      Console.Write(newResults);
      Console.WriteLine();

      ///////////////////////////////////////////////////////////////
      // Create and Parse TestResults message

      "Testing Creation and Parsing of TestResults Message".title();

      Console.Write("\n  Creating Message using TestResults data structure\n");
      Message rltsMsg = new Message();
      rltsMsg.to = "CL";
      rltsMsg.from = "TH";
      rltsMsg.type = "TestResults";
      rltsMsg.author = "TestHarness";
      rltsMsg.time = DateTime.Now;
      rltsMsg.body = rslts.ToXml();
      rltsMsg.show();

      Console.Write("\n  retrieving testResults object:");
      TestResults newTr = rltsMsg.body.FromXml<TestResults>();
      Console.Write("\n{0}", newTr);
      Console.Write("\n\n");
    }
  }
#endif
}
