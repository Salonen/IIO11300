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
            int drawns = int.Parse(textBox.Text);

            try
            {


                if (comboBox.SelectedItem == "Suomi") {
                    tulos=Lotto.Suomi(drawns);
                }
                else if (comboBox.SelectedItem == "VikingLotto")
                {
                    tulos = Lotto.Viking(drawns);
                }

                else if (comboBox.SelectedItem == "EuroJackpot")
                {
                    tulos = Lotto.Euro(drawns);
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