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

        List<Viini> wine = new List<Viini>();
        List<Viini> SortedList = new List<Viini>();
        //List<string> ma3a;
        List<string> maa = new List<string>();
        List<string> maa2 = new List<string>();

        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"G:\C#2\Viinit1.xml");

                XmlNodeList elemList = doc.GetElementsByTagName("nimi");
                XmlNodeList elemList2 = doc.GetElementsByTagName("arvio");
                XmlNodeList elemList3 = doc.GetElementsByTagName("maa");

                wine.Clear();

                for (int i = 0; i < elemList.Count; i++)
                {
                    wine.Add(new Viini(elemList[i].InnerText, elemList3[i].InnerText, int.Parse(elemList2[i].InnerText)));

                }
                SortedList.Clear();
                SortedList = wine.OrderBy(o => o.Nimi).ToList();

                //comboBox.Items.Clear();

                
                for (int n = 0; n < SortedList.Count; n++)
                {
                    listBox.Items.Add(SortedList[n].Nimi + " : " + SortedList[n].Arvio.ToString() + " : " + SortedList[n].Maa);
                
                
                }
                string joo;
                maa.Clear();
                for(int m = 0; m < SortedList.Count; m++)
                {
                joo = SortedList[m].Maa;
                maa.Add(joo);
                }
                maa2 = maa.Distinct().ToList();
            //maa.Distinct();
            /*for (int m = 0; m < maa2.Count; m++)*/
            comboBox.Items.Clear();
            for (int r=0;r < maa2.Count;r++) comboBox.Items.Add(maa2[r]);

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

        /*private Boolean Check(string osa,List<string> onko)
        {
            for(int p = 0; p < (onko.Count); p++)
            {
                if (osa == onko[p]) return true;
            }
            return false;
        }*/



        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                listBox.Items.Clear();
                

                for (int n = 0; n < SortedList.Count; n++)
                {
                if (comboBox.Items.Count > 0)
                {
                    if (comboBox.SelectedValue.ToString() == SortedList[n].Maa.ToString())
                    {
                        listBox.Items.Add(SortedList[n].Nimi + " : " + SortedList[n].Arvio.ToString() + " : " + SortedList[n].Maa);
                    }
                }

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
