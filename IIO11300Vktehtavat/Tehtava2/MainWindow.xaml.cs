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
//using System.Windows.Shapes.Path;

using System.IO; // Muista lisätä tämä

namespace Tehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBox.Items.Add("Suomi");
            comboBox.Items.Add("VikingLotto");
            comboBox.Items.Add("EuroJackpot");
            
            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Class2.joo();
             try
            {
                //if (comboBox.SelectedItem == "Suomi") ;
                /*switch (comboBox.SelectedItem)
                {
                    case "Suomi": break;
                    case "VikingLotto": break;
                }*/
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Class2.joo();
           
            
            string tulos = "";
            int drawns = int.Parse(textBox.Text), laskuri;
            Random rnd = new Random();

            try
            {


                if (comboBox.SelectedItem == "Suomi") {
                    for(laskuri=0;laskuri<drawns;laskuri++) tulos +=Lotto.Luvut(7,39, rnd);
                }
                else if (comboBox.SelectedItem == "VikingLotto")
                {
                    for (laskuri = 0; laskuri < drawns; laskuri++) tulos += Lotto.Luvut(6,48, rnd);
                }

                else if (comboBox.SelectedItem == "EuroJackpot")
                {
                    for (laskuri = 0; laskuri < drawns; laskuri++) tulos += Lotto.Luvut(5,50, rnd) + " : " + Lotto.Luvut(2,8, rnd);
                }
                /*switch (comboBox.SelectedItem)
                {
                    case "Suomi": break;
                    case "VikingLotto": break;
                }*/
                textBlock2.Text = tulos;
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                textBlock2.Text = "";
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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Environment.Exit(1);
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

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //kirjoitetaan annettu teksti tiedostoon riittävän monta kertaa
                string filename = textBox1.Text;
                int count = 1;
                //int.TryParse(txtCount.Text, out count);
                /*if (!File.Exists(textBox1.Text))
                {
                    File.Create(textBox1.Text);
                }*/

                //new DirectoryInfo(Path.GetDirectoryName(filename)).Create();
                //string file = @".\aa\b\file.txt";
                //Directory.CreateDirectory(Path.GetDirectoryName(filename));

                /*FileInfo fi = new FileInfo(@".\a\bb\file.txt");
                DirectoryInfo di = new DirectoryInfo(@".\a\bb");
                if (!di.Exists)
                {
                    di.Create();
                }

                if (!fi.Exists)
                {
                    fi.Create().Dispose();
                }*/

                FileInfo fileInfo = new FileInfo(filename);

                if (!fileInfo.Exists)
                    Directory.CreateDirectory(fileInfo.Directory.FullName);


                //create the file ...

                {
                    using (StreamWriter sw = File.CreateText(filename))
                    {
                        for (int i = 1; i <= count; i++)
                        {
                            sw.WriteLine(textBlock2.Text);
                        }
                        sw.Close();
                    }
                    tbMessages.Text = String.Format("Kirjoitettu {0} riviä tiedostoon {1}", count, filename);
                }
            }
            catch (Exception ex)
            {

                tbMessages.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            textBlock2.Text = null;
            //luetaan teksitiedostoa rivi kerrallaan
            string filename = textBox1.Text;
            string line = null;
            if (filename.Length > 0)
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    line = null;
                    do
                    {
                        line = sr.ReadLine();
                        textBlock2.Text += line + "\n";
                    } while (line != null);
                }
            }
        }
    }
}

/*public class BusinessLogicWindow
{
    /// <summary>
    /// CalculatePerimeter calculates the perimeter of a window
    /// </summary>
    public static void Suomi()
    {
        //throw new System.NotImplementedException();

    }
    public static void Viking()
    {
        //throw new System.NotImplementedException();
      
    }
    public static void Euro()
    {
      
    }
}*/



/*namespace Tehtava2
{
    class Class2
    {
        public static void joo()
        {
            comboBox.Items.Add("Sunday");
            comboBox.Items.Add("Monday");
        }
    }
}*/