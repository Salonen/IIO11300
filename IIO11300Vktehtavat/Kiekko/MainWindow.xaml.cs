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
//using System;
using System.IO;
//using System.IO.Path;

namespace Kiekko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pelaaja> pelaajat = new List<Pelaaja>();

        public MainWindow()
        {
            InitializeComponent();
            comboBox.Items.Add("HIFK");
            comboBox.Items.Add("HPK");
            comboBox.Items.Add("Ilves");
            pelaajat.Add(new Pelaaja("sss", "sss", "sss", 10));
            //list.Add = pelaaja;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int tyhja = 1;

            //if (!string.IsNullOrEmpty(textBox.Text)/* != ""*/ &&
            //  textBox1.Text != "" &&
            //!string.IsNullOrEmpty(textBox2.Text) &&
            //textBox2.Text.All(Char.IsDigit) &&
            //!string.IsNullOrEmpty(comboBox.Text));//&& comboBox.SelectedItem.ToString() != "" && comboBox.SelectedItem.ToString() != null)*/
            if (!string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                textBox2.Text.All(char.IsDigit) && !string.IsNullOrEmpty(comboBox.Text))
            {
                for (int n = 0; n < pelaajat.Count; n++)
                {
                    if (pelaajat[n].Etunimi == textBox.Text && pelaajat[n].Sukunimi == textBox1.Text) tyhja = 0;
                }

                if (tyhja == 1)
                {
                    pelaajat.Add(new Pelaaja(textBox.Text, textBox1.Text, comboBox.SelectedItem.ToString(), int.Parse(textBox2.Text)));
                    //int i = pelaajat.Etunimi.IndexOf(textBox.Text);

                    //Class1 newTile = new Class1(num, x * 32 + cameraX, y * 32 + cameraY);
                    //MapTiles.Add(pelaajat);
                    //int i= MapTiles.IndexOf(pelaajat);

                    /* listBox.Items.Add(pelaajat[i].Etunimi);
                     listBox.Items.Add(pelaajat[i].Sukunimi);
                     listBox.Items.Add(pelaajat[i].Siirtohinta);
                     listBox.Items.Add(pelaajat[i].Seura);*/
                    listBox.Items.Add(textBox.Text + textBox1.Text + comboBox.Text);
                    /*listBox.Items.Add(textBox.Text);
                    listBox.Items.Add(textBox1.Text);
                    listBox.Items.Add(textBox2.Text);
                    listBox.Items.Add(comboBox.Text);*/
                }
            }


        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox.Items.Clear();

            for (int n = 0; n < pelaajat.Count; n++)
            {
                if (pelaajat[n].Seura == comboBox.SelectedItem)
                {
                    listBox.Items.Add(pelaajat[n].EsitysNimi);
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int tyhja = 1, mika = -1;

            //if (!string.IsNullOrEmpty(textBox.Text)/* != ""*/ &&
            //  textBox1.Text != "" &&
            //!string.IsNullOrEmpty(textBox2.Text) &&
            //textBox2.Text.All(Char.IsDigit) &&
            //!string.IsNullOrEmpty(comboBox.Text));//&& comboBox.SelectedItem.ToString() != "" && comboBox.SelectedItem.ToString() != null)*/
            if (!string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                textBox2.Text.All(char.IsDigit) && !string.IsNullOrEmpty(comboBox.Text))
            {
                for (int n = 0; n < pelaajat.Count; n++)
                {
                    if (pelaajat[n].EsitysNimi != listBox.SelectedItem.ToString())
                    {
                        if (pelaajat[n].Etunimi == textBox.Text && pelaajat[n].Sukunimi == textBox1.Text) tyhja = 0;
                    }
                    else mika = n;
                }

                if (tyhja == 1 && mika != -1)
                {
                    //pelaajat.Add(new Pelaaja(textBox.Text, textBox1.Text, comboBox.SelectedItem.ToString(), int.Parse(textBox2.Text)));
                    pelaajat[mika].Etunimi = textBox.Text;
                    pelaajat[mika].Sukunimi = textBox1.Text;
                    pelaajat[mika].Siirtohinta = int.Parse(textBox2.Text);
                    //int i = pelaajat.Etunimi.IndexOf(textBox.Text);

                    //Class1 newTile = new Class1(num, x * 32 + cameraX, y * 32 + cameraY);
                    //MapTiles.Add(pelaajat);
                    //int i= MapTiles.IndexOf(pelaajat);

                    /* listBox.Items.Add(pelaajat[i].Etunimi);
                     listBox.Items.Add(pelaajat[i].Sukunimi);
                     listBox.Items.Add(pelaajat[i].Siirtohinta);
                     listBox.Items.Add(pelaajat[i].Seura);*/
                    //listBox.Items.Add(textBox.Text + textBox1.Text + comboBox.Text);
                    /*listBox.Items.Add(textBox.Text);
                    listBox.Items.Add(textBox1.Text);
                    listBox.Items.Add(textBox2.Text);
                    listBox.Items.Add(comboBox.Text);*/
                }
                listBox.Items.Clear();

                for (int n = 0; n < pelaajat.Count; n++)
                {
                    if (pelaajat[n].Seura == comboBox.SelectedItem)
                    {
                        listBox.Items.Add(pelaajat[n].EsitysNimi);
                    }
                }
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.Items.Count > 0)
            {
                for (int n = 0; n < pelaajat.Count; n++)
                {
                    if (pelaajat[n].EsitysNimi == listBox.SelectedItem.ToString())
                    {
                        textBox.Text = pelaajat[n].Etunimi;
                        textBox1.Text = pelaajat[n].Sukunimi;
                        textBox2.Text = pelaajat[n].Siirtohinta.ToString();
                    }
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                MessageBox.Show("Please select an Item first!");

            else if (listBox.Items.Count > 0)
            {
                for (int n = 0; n < pelaajat.Count; n++)
                {
                    if (pelaajat[n].EsitysNimi == listBox.SelectedItem.ToString())
                    {
                        pelaajat.RemoveAt(n);
                        //pelaajat[n].;
                    }
                }

                listBox.Items.Clear();

                for (int n = 0; n < pelaajat.Count; n++)
                {
                    if (pelaajat[n].Seura == comboBox.SelectedItem)
                    {
                        listBox.Items.Add(pelaajat[n].EsitysNimi);
                    }
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            /*string dir = @"d:\temp";
            string serializationFile = "k.bin"; // Path.Combine(dir, "k.bin");
            FileInfo fileInfo = new FileInfo(serializationFile);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);

            //serialize
            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, pelaajat);
            }




            /* Stream stream = new FileStream("D:\temp\kiekko.dat", FileMode.Create);
             BinaryWriter binWriter = new BinaryWriter(stream);
             binWriter.Write(pelaajat.Count);
             foreach (Pelaaja _string in pelaajat)
             {
                 binWriter.Write(_string);
             }
             binWriter.Close();
             stream.Close();*/

            /*Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }*/
        }


        /*
        private static void write()
        {
            List<string> list = new List<string>();
            list.Add("ab");
            list.Add("db");
            Stream stream = new FileStream("D:\\Bar.dat", FileMode.Create);
            BinaryWriter binWriter = new BinaryWriter(stream);
            binWriter.Write(list.Count);
            foreach (string _string in list)
            {
                binWriter.Write(_string);
            }
            binWriter.Close();
            stream.Close();
        }

        private static void read()
        {
            List<string> list = new List<string>();
            Stream stream = new FileStream("D:\\Bar.dat", FileMode.Open);
            BinaryReader binReader = new BinaryReader(stream);

            int pos = 0;
            int length = binReader.ReadInt32();
            while (pos < length)
            {
                list.Add(binReader.ReadString());
                pos++;
            }
            binReader.Close();
            stream.Close();
        }*/
    }
}



   /* /// <summary>
    /// Writes the given object instance to a binary file.
    /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
    /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
    /// </summary>
    /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
    /// <param name="filePath">The file path to write the object instance to.</param>
    /// <param name="objectToWrite">The object instance to write to the XML file.</param>
    /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
    private static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
    {
        using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, objectToWrite);
        }
    }

    /// <summary>
    /// Reads an object instance from a binary file.
    /// </summary>
    /// <typeparam name="T">The type of object to read from the XML.</typeparam>
    /// <param name="filePath">The file path to read the object instance from.</param>
    /// <returns>Returns a new instance of the object read from the binary file.</returns>
    public static T ReadFromBinaryFile<T>(string filePath)
    {
        using (Stream stream = File.Open(filePath, FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (T)binaryFormatter.Deserialize(stream);
        }
    }
}*/

 /*   using System.IO;

    [Serializable]
    class salesman
    {
        public string name, address, email;
        public int sales;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<salesman> salesmanList = new List<salesman>();
            string dir = @"c:\temp";
            string serializationFile = Path.Combine(dir, "salesmen.bin");

            //serialize
            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, salesmanList);
            }

            //deserialize
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                List<salesman> salesman = (List<salesman>)bformatter.Deserialize(stream);
            }
        }
    }*/