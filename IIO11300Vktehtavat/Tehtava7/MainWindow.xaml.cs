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

namespace Tehtava7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //textBox5.PasswordChar = '*';
            //textBox5.PasswordChar = '*';



        }

        /*private void PasswordChangedHandler(Object sender, RoutedEventArgs e)
        {
            // Increment a counter each time the event fires.
            

        }*/

        /* private void checkBox_Checked(object sender, RoutedEventArgs e)
         {

         }*/

        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            string jono = textBox5.Text.ToString();

            //textBox2.Text = jono;
            //textBox5.PasswordChar = '*';

            int count = 0;
            for (int i = 0; i < jono.Length; i++)
            {
                if (char.IsUpper(jono[i])) count++;
            }
            textBox1.Text = "Isoja : " + count.ToString();
            int count2 = 0;
            for (int i = 0; i < jono.Length; i++)
            {
                if (char.IsLower(jono[i])) count2++;
            }
            textBox2.Text = "Pieniä : " + count2.ToString();
            int count3 = 0;
            for (int i = 0; i < jono.Length; i++)
            {
                if (char.IsDigit(jono[i])) count3++;
            }
            textBox3.Text = "Numeroita : " + count3.ToString();
            int count4 = 0;
            for (int i = 0; i < jono.Length; i++)
            {
                if (!char.IsDigit(jono[i]) && !char.IsLower(jono[i]) && !char.IsUpper(jono[i])) count4++;
            }
            textBox4.Text = "Muita : " + count4.ToString();
            int maara = 0;
            if (count > 0) maara++;
            if (count2 > 0) maara++;
            if (count3 > 0) maara++;
            if (count4 > 0) maara++;

            if (jono.Length < 8 || maara<=1) textBox.Text = "Bad";
            //if (jono.Length < 8 && maara == 2) textBox.Text = "Fair";
            if (maara > 1)
            {
                if(jono.Length>=8) textBox.Text = "Fair";
            }
            if (maara > 2)
            {
                if (jono.Length >= 8 && jono.Length<12) textBox.Text = "Fair";
                if(jono.Length>=12) textBox.Text = "Moderate";
            }
            if (maara > 3)
            {
                if (jono.Length >= 8 && jono.Length < 12) textBox.Text = "Fair";
                if (jono.Length >= 12 && jono.Length <16) textBox.Text = "Moderate";
                if(jono.Length>=16) textBox.Text = "Good";
            }
            /*if ((jono.Length >= 8) && (maara > 1)) textBox.Text = "Fair";
            if ((jono.Length >= 12) && (maara > 2 )) textBox.Text = "Moderate";
            if ((jono.Length >= 16) && (maara > 3 )) textBox.Text = "Good";*/

            /*if (jono.Length < 8 || maara <= 1) textBox.Text = "Bad";
            //if (jono.Length < 8 && maara == 2) textBox.Text = "Fair";
            if ((jono.Length >= 8 && jono.Length < 12) && (maara > 1)) textBox.Text = "Fair";
            if ((jono.Length >= 12 && jono.Length < 16) && (maara > 2)) textBox.Text = "Moderate";
            if ((jono.Length >= 16) && (maara > 3)) textBox.Text = "Good";*/
        }
    }

   /* public PasswordChangedHandler(Object sender, RoutedEventArgs e)
    {
        // Increment a counter each time the event fires.
        
    }*/
}
