using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//[Serializable()]
namespace Kiekko
{
    [Serializable()]
    class Pelaaja
    {
        private string etunimi, sukunimi, seura;
        private int siirtohinta;

        public Pelaaja()
        {

        }

        public Pelaaja(string etunimi, string sukunimi, string seura, int siirtohinta)
        {
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.seura = seura;
            this.siirtohinta = siirtohinta;            
            
            //Console.WriteLine(x);
        }

        public string Etunimi
        {
            get
            {
                return etunimi;
            }
            set
            {
                etunimi = value;
            }
        }

        public string Sukunimi
        {
            get
            {
                return sukunimi;
            }
            set
            {
                sukunimi = value;
            }
        }

        public string Seura
        {
            get
            {
                return seura;
            }
            set
            {
                seura = value;
            }
        }

        public int Siirtohinta
        {
            get
            {
                return siirtohinta;
            }
            set
            {
                siirtohinta = value;
            }
        }

        public string KokoNimi
        {
            get
            {
                return sukunimi + etunimi;
            }
        }

        public string EsitysNimi
        {
            get
            {
                return etunimi + sukunimi + seura;
            }
        }
    }
}
