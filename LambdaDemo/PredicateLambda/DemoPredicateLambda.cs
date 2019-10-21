/////////////////////////////////////////////////////////////////////////
// DemoPredicateLambda.cs - demonstrate queries using queryPredicates  //
//                                                                     //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2015     //
/////////////////////////////////////////////////////////////////////////
/*
 * This example demonstrates how to set up queries in a way useful
 * for Project #2, Fall 2015.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityExtensions;
using static System.Console;

namespace LambdaDemos
{
  class DemoPredicateLambdas
  {
    // This string array pretends to be a key/value database.

    string[] db = new string[] {
      "this is a test that ...", "fee and foo and Bar", "rumor has it that ..."
    };
    
    //----< build queryPredicate >-------------------------------------
    /*
     * Query returns true if query(key) condition is satisfied.
     * In this example the query is checking to see if the query
     * parameter, the captured string, test, is a substring of
     * the database element referenced by key.
     */
    Func<int, bool> defineQuery(string test)
    {
      // Func<int, bool> is delegate that binds to 
      // functions of the form bool query(int key).

      Func<int, bool> queryPredicate = (int key) =>
      {
        if (key < 0 || key >= db.Count())
          return false;
        if (db[key].Contains(test))  // string test will be captured by lambda
          return true;
        return false;
      };
      return queryPredicate;
    }
    //----< process query using queryPredicate >-----------------------

    bool processQuery(Func<int, bool> queryPredicate, out List<int> keyCollection)
    { /*
       * step through all the keys in the db to see if
       * the queryPredicate is true for one or more keys.
       */
      keyCollection = new List<int>();
      for (int i = 0; i < db.Count(); ++i)
      {
        if (queryPredicate(i))
        {
          keyCollection.Add(i);
        }
      }
      if (keyCollection.Count() > 0)
        return true;
      return false;
    }
    //----< show query results >---------------------------------------

    void showQueryResults(bool result, List<int> keyCollection, string queryParam)
    {
      if (result) // query succeeded for at least one key
      {
        foreach(int key in keyCollection)
          Write("\n  found \"{0}\" in \"{1}\" at key value {2}", queryParam, db[key], key);
      }
      else
      {
        Write("\n  query failed with queryParam \"{0}\"", queryParam);
      }
    }
    static void Main(string[] args)
    {
      "LambdaDemo.PredicateLambda - Demonstrating queryPredicate".title('=');
      WriteLine();

      DemoPredicateLambdas dpl = new DemoPredicateLambdas();

      // build query
      string search = "foo and";
      Func<int, bool> query = dpl.defineQuery(search);

      // process query
      List<int> keyCollection;
      bool result = dpl.processQuery(query, out keyCollection);
      dpl.showQueryResults(result, keyCollection, search);

      search = "that ...";
      query = dpl.defineQuery(search);
      result = dpl.processQuery(query, out keyCollection);
      dpl.showQueryResults(result, keyCollection, search);

      search = "Queen of Hearts";
      query = dpl.defineQuery(search);
      result = dpl.processQuery(query, out keyCollection);
      dpl.showQueryResults(result, keyCollection, search);

      Write("\n\n");
    }
  }
}
