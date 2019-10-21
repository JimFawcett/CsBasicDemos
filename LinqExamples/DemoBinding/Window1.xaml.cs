///////////////////////////////////////////////////////////////
// Window1.Xaml.cs - Demonstrate Binding to XML              //
//                                                           //
// Jim Fawcett, CSE775 - Distributed Objects, Spring 2009    //
///////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoBinding
{
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      XDocument doc = XDocument.Load("..\\..\\DemoBinding.xml");
      var q = from x in doc.Elements("DataBindDemo").Elements("item") select x.Value;
      List<string> items = q.ToList();
      listBox2.ItemsSource = items;
    }
  }
}
