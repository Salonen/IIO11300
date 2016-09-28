using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava6
{
    class Viini
    {
        private string nimi, maa;
        private int arvio;

        public Viini()
        {

        }

        public Viini(string nimi, string maa, int arvio)
        {
            this.nimi = nimi;
            this.maa = maa;
            this.arvio = arvio;

            //Console.WriteLine(x);
        }

        public string Nimi
        {
            get
            {
                return nimi;
            }
            set
            {
                nimi = value;
            }
        }

        public string Maa
        {
            get
            {
                return maa;
            }
            set
            {
                maa = value;
            }
        }
        public int Arvio
        {
            get
            {
                return arvio;
            }
            set
            {
                arvio = value;
            }
        }
    }
}
