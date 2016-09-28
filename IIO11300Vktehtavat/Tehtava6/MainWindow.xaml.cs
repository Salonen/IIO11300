using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Runtime.Serialization.Formatters.Binary;

using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Tehtava6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*private static XElement Sort(XElement element)
        {
            return new XElement(element.Name,
                    from child in element.Elements()
                    orderby child.Name.ToString()
                    select Sort(child));
        }*/

        /*private static XDocument Sort(XDocument file)
        {
            return new XDocument(Sort(file.Root));
        }*/

        private void button_Click(object sender, RoutedEventArgs e)
        {

            Viini joo = new Viini();
            List<Viini> wine = new List<Viini>();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"G:\C#2\Viinit1.xml");

               // List<Order> SortedList = objListOrder.OrderBy(o=>o.OrderDate).ToList();

                XmlNodeList elemList =  doc.GetElementsByTagName("nimi");
                XmlNodeList elemList2 = doc.GetElementsByTagName("arvio");
                XmlNodeList elemList3 = doc.GetElementsByTagName("maa");

                for (int i = 0; i < elemList.Count; i++)
                {
                    //listBox.Items.Add(elemList[i].InnerXml + " : " + elemList2[i].InnerXml + " : " + elemList3[i].InnerXml);

                    /*joo.Nimi = elemList[i].InnerText;
                    joo.Maa = elemList3[i].InnerText;
                    joo.Arvio = int.Parse(elemList2[i].InnerText);*/
                    wine.Add(new Viini(elemList[i].InnerText,elemList3[i].InnerText,int.Parse(elemList2[i].InnerText)));
                    //listBox.Items.Add(wine[i].Nimi + " : " + wine[i].Arvio + " : " + wine[i].Maa);
                    
                    //wine.Add(joo);
                }

                List<Viini> SortedList = wine.OrderBy(o => o.Nimi).ToList();
                //listBox.Items.Add(wine[1].Nimi + " : " + wine[1].Arvio + " : " + wine[1].Maa);

                for (int n = 0; n < wine.Count; n++)
                {
                    listBox.Items.Add(SortedList[n].Nimi + " : " + SortedList[n].Arvio.ToString() + " : " + SortedList[n].Maa);
                    //listBox.Items.Add(wine[i].Nimi + " : " + wine[i].Arvio + " : " + wine[i].Maa);
                    /*wine[i].Nimi = elemList[i].InnerText;
                    wine[i].Maa = elemList3[i].InnerText;
                    wine[i].Arvio = int.Parse(elemList2[i].InnerText);*/
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }

        }
    }
}
