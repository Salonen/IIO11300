using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
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
    class Lotto
    {
        public static string Suomi(int drawns)
        {
            //comboBox.Items.Add("Sunday");
            //comboBox.Items.Add("Monday");
            Random rnd = new Random();
            int numero,n;
            //taul = new int[7];
            int[] taul = new int[7];
            string palautus="";

            for (int m = 0; m < drawns; m++)
            {
                for (n = 0; n < 7; n++)
                {
                    numero = rnd.Next(1, 39+1); // creates a number between 1 and 12
                                              //numero = 10;
                    taul[n] = numero;
                }
                for (n = 0; n < 7; n++)
                {
                    numero = rnd.Next(1, 39+1); // creates a number between 1 and 12
                                              //numero = 10;
                    palautus += " " + numero.ToString();
                }
                palautus += "\n";
            }

            return palautus;
        }

        public static string Viking(int drawns)
        {
            //comboBox.Items.Add("Sunday");
            //comboBox.Items.Add("Monday");
            Random rnd = new Random();
            int numero, n;
            //taul = new int[7];
            int[] taul = new int[6];
            string palautus = "";

            for (int m = 0; m < drawns; m++)
            {
                for (n = 0; n < 6; n++)
                {
                    numero = rnd.Next(1, 48+1); // creates a number between 1 and 12
                                              //numero = 10;
                    taul[n] = numero;
                }
                for (n = 0; n < 6; n++)
                {
                    numero = rnd.Next(1, 48+1); // creates a number between 1 and 12
                                              //numero = 10;
                    palautus += " " + numero.ToString();
                }
                palautus += "\n";
            }

            return palautus;
        }

        public static string Euro(int drawns)
        {
            //comboBox.Items.Add("Sunday");
            //comboBox.Items.Add("Monday");
            Random rnd = new Random();
            int numero, n;
            //taul = new int[7];
            int[] taul = new int[5];
            string palautus = "";

            for (int m = 0; m < drawns; m++)
            {
                for (n = 0; n < 5; n++)
                {
                    numero = rnd.Next(1, 50+1); // creates a number between 1 and 12
                                              //numero = 10;
                    taul[n] = numero;
                }
                for (n = 0; n < 5; n++)
                {
                    numero = rnd.Next(1, 50+1); // creates a number between 1 and 12
                                              //numero = 10;
                    palautus += " " + numero.ToString();
                }
                palautus += "  ";
                for (n = 0; n < 2; n++)
                {
                    numero = rnd.Next(1, 8+1); // creates a number between 1 and 12
                                              //numero = 10;
                    palautus += " " + numero.ToString();
                }
                palautus += "\n";
            }

            

            return palautus;
        }
    }
}
