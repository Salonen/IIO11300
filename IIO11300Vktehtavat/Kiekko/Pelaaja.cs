﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

//[Serializable()]
namespace Kiekko
{
    [Serializable()]
    public class Pelaaja  /// PUBLIC
    {
        private string etunimi, sukunimi, seura;
        private int siirtohinta,tila,id;

        public Pelaaja()
        {

        }

        public Pelaaja(string etunimi, string sukunimi, string seura, int siirtohinta,int tila,int id)
        {
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.seura = seura;
            this.siirtohinta = siirtohinta;
            this.tila = tila;
            this.id = id;
            
            //Console.WriteLine(x);
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int Tila
        {
            get
            {
                return tila;
            }
            set
            {
                tila = value;
            }
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
