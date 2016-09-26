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
    class Lotto
    {
        public static string Luvut(int monta, int alue, Random rnd)
        {
            
            int numero,n,m;
            int[] taul = new int[monta];
            int[] taul2 = new int[alue+1];
            string palautus="";

            for (n = 0; n < alue+1; n++) taul2[n] = n;

            for (n = 0; n < monta; n++)
            {
                taul[n] = numero = taul2[rnd.Next(1, alue+1-n)];

                taul2[numero] = taul2[alue - n];
            }

            for (n = 0; n < monta; n++)
                {
                    palautus += " " + taul[n].ToString();
                }
                palautus += "\n";
            return palautus;
        }
    }
}
