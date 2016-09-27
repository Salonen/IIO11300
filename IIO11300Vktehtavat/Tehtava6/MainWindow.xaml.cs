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
//using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;

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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            /*XmlDocument doc = new XmlDocument();
            doc.Loadxml(@"G:\C#2\Viinit1.xml");*/


            /*XmlDocument doc = new XmlDocument();
            doc.Load("path to your file");
            string xmlcontents = doc.InnerXml;*/

            /*string xml = @"<?xml version='1.0' encoding='utf-8'?>
                       <root>
                       <date>12/03/2001</date>
                       <child>
                         <name>Aravind</name>
                         <date>12/03/2000</date>
                       </child>
                       <name>AS-CII</name>
                       </root>";*/
             XmlDocument doc = new XmlDocument();
             doc.Load(@"G:\C#2\Viinit1.xml");
            //string xmlcontents = doc.InnerXml;

            XmlNodeList elemList = doc.GetElementsByTagName("nimi"); // NIMIIIIIIIIIII !!!!!!!!!
            for (int i = 0; i < elemList.Count; i++)
            {
                listBox.Items.Add(elemList[i].InnerXml);
            }

            //listBox.Items.Add(xmlcontents);

            /*xmlcontents.name = node.SelectSingleNode("name").InnerText;
            xmlcontents.date = node.SelectSingleNode("date").InnerText;
            xmlcontents.sub = node.SelectSingleNode("subject").InnerText;*/

            //XDocument doc = XDocument.Parse(@"G:\C#2\Viinit1.xml");

            /*foreach (var nimi in doc.Descendants("nimi"))
            {
                listBox.Items.Add(nimi);
            }*/

            /*XmlDocument doc = new XmlDocument();
            doc.Load("path to your file");
            string xmlcontents = doc.InnerXml;*/
            /*
                        foreach (var date in doc.Descendants("name"))
                        {
                            Console.WriteLine(date.Value);
                        }*/

            //Console.ReadLine();


            /*XmlDocument doc = new XmlDocument();
            doc.Load(@"G:\C#2\Viinit1.xml");
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//*");
            string date;
            string name2;

            foreach (XmlNode node in nodes)
            {
                var dateNode = node["name"];
                if (dateNode != null)
                {
                    date = dateNode.InnerText;
                    listBox.Items.Add(dateNode);
                }

                // etc.
            }*/

            /*            foreach (XmlNode node in nodes)
                        {
                            date = node["date"].InnerText;
                            name = node["name"].InnerText;
                        }*/



            /*XDocument document = XDocument.Load(@"G:\C#2\Viinit1.xml");
            var wine = from i in document.Descendants("wine")
                       select new
                       {
                           nimi = i.Element("nimi").Value
                           /*Title = i.Element("Title").Value,
                           Body = i.Element("Body").Value,
                           LinkText = i.Element("LinkText").Value,
                           LinkUrl = i.Element("LinkUrl").Value*/
            /*};
 listBox.Items.Add(wine.nimi);*/


            /*      left.Title
             left.Body
             left.LinkText
             l       eft.LinkUrl*/


            /* var userInfos = XElement.Load(@"G:\C#2\Viinit1.xml").Descendants("userInfo").Select(elt =>
             {
                 var line = elt.Descendants();
                 return string.Join(",", line.Select(subElt => subElt.Value));
             });
             listBox.Items.Add(userInfos);*/
            //pelaajat[n].Seura
            /*foreach (var userInfo in userInfos)
            {
                listBox.Items.Add(userInfo);
                //listBox.Items.Add(textBox.Text + textBox1.Text + comboBox.Text);
            }*/
        }
    }
}
