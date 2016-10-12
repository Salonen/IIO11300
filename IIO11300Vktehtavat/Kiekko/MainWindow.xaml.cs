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
using System.IO;  
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data.OleDb; // for database !!!!!!!!!!!!
//using System;
using System.Data;  //sisältää ADO;n perusluokat
using System.Data.SqlClient; //SQL Server spesifiset luokat
using System.Web;
using MySql.Data.MySqlClient;
//System.Data.SqlClient

namespace Kiekko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pelaaja> pelaajat = new List<Pelaaja>();
        DataTable dt = new DataTable();

        public MainWindow()
        {
            InitializeComponent();
            comboBox.Items.Add("HIFK");
            comboBox.Items.Add("HPK");
            comboBox.Items.Add("Ilves");

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int tyhja = 1;

            try
            {
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

                        listBox.Items.Add(textBox.Text + textBox1.Text + comboBox.Text);
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

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                listBox.Items.Clear();

                for (int n = 0; n < pelaajat.Count; n++)
                {
                    if (pelaajat[n].Seura == comboBox.SelectedItem.ToString())
                    {
                        listBox.Items.Add(pelaajat[n].EsitysNimi);
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int tyhja = 1, mika = -1;

            try
            {
                if (!string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                    textBox2.Text.All(char.IsDigit) && !string.IsNullOrEmpty(comboBox.Text))
                {
                    for (int n = 0; n < pelaajat.Count; n++)
                    {
                        if (pelaajat[n].EsitysNimi != listBox.SelectedItem.ToString() && (listBox.Items.Count > 0))
                        {
                            if (pelaajat[n].Etunimi == textBox.Text && pelaajat[n].Sukunimi == textBox1.Text) tyhja = 0;
                        }
                        else mika = n;
                    }

                    if (tyhja == 1 && mika != -1)
                    {
                        pelaajat[mika].Etunimi = textBox.Text;
                        pelaajat[mika].Sukunimi = textBox1.Text;
                        pelaajat[mika].Siirtohinta = int.Parse(textBox2.Text);

                    }
                    listBox.Items.Clear();

                    for (int n = 0; n < pelaajat.Count; n++)
                    {
                        if (pelaajat[n].Seura == (string)comboBox.SelectedItem) // string
                        {
                            listBox.Items.Add(pelaajat[n].EsitysNimi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Oletko valinnut?");

            }
            finally
            {
                //yield to an user that everything okay
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
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
                if (listBox.SelectedIndex == -1)
                    MessageBox.Show("Please select an Item first!");

                else if (listBox.Items.Count > 0)
                {
                    for (int n = 0; n < pelaajat.Count; n++)
                    {
                        if (pelaajat[n].EsitysNimi == listBox.SelectedItem.ToString())
                        {
                            pelaajat.RemoveAt(n);

                        }
                    }

                    listBox.Items.Clear();

                    for (int n = 0; n < pelaajat.Count; n++)
                    {
                        if (pelaajat[n].Seura == (string)comboBox.SelectedItem) // string
                        {
                            listBox.Items.Add(pelaajat[n].EsitysNimi);
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


        private void button3_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var serializer = new BinaryFormatter();
                using (var stream = File.OpenWrite(@"d:\MyTest"))
                {
                    serializer.Serialize(stream, pelaajat);
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

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var serializer = new BinaryFormatter();

                using (var stream = File.OpenRead(@"d:\MyTest"))
                {
                    pelaajat = (List<Pelaaja>)serializer.Deserialize(stream);
                }
                listBox.Items.Clear();
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


        private void button6_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Pelaaja>));


                using (FileStream stream = File.OpenWrite(@"d:\MyTestxml"))
                {
                    serializer.Serialize(stream, pelaajat);
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

        private void button7_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Pelaaja>));


                using (FileStream stream = File.OpenRead(@"d:\MyTestxml"))
                {
                    pelaajat = (List<Pelaaja>)serializer.Deserialize(stream);
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

        private void button8_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            string cs = "server=mysql.labranet.jamk.fi;user=H8482;" + "pwd=HS1gRvSg2Kv4YCYChteSNOD7pBfSNPh1;database=H8482;"; //@
                                                                            // salasana piilossa
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                conn = new MySqlConnection(cs);
                

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = String.Format("DELETE FROM pelaajat");

                // "The original string: '{0}'", original
                conn.Open();
                command.ExecuteNonQuery();
                for (int i = 0; i < pelaajat.Count; i++)
                {
                    command.CommandText = String.Format("INSERT INTO pelaajat (etunimi, sukunimi, siirtohinta, seura ) VALUES('{0}', '{1}', '{2}', '{3}')", pelaajat[i].Etunimi, pelaajat[i].Sukunimi, pelaajat[i].Siirtohinta, pelaajat[i].Seura);//"INSERT INTO tb_mitarbeiter (Vorname) VALUES ('tom')";
                    command.ExecuteNonQuery();
                }


                

                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }

            }


        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            string cs = "server=mysql.labranet.jamk.fi;user=H8482;" + "pwd=HS1gRvSg2Kv4YCYChteSNOD7pBfSNPh1;database=H8482;"; //@
                                                                        // salasana piilossa
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM pelaajat";

                MySqlCommand  cmd = new MySqlCommand(stm, conn);

                //conn.Open();

                DataTable dt2 = new DataTable();



                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt2);
                }

                 textBox.Text= dt2.Rows[0].ToString();
                
                int i = 0;
                string seura;
                while (i < dt2.Rows.Count )
                {
                    seura = dt2.Rows[i]["seura"].ToString();

                    textBox.Text = dt2.Rows[i]["etunimi"].ToString();
                    textBox1.Text = dt2.Rows[i]["sukunimi"].ToString();
                    textBox2.Text = dt2.Rows[i++]["siirtohinta"].ToString();
                    comboBox.Items.Add(seura);
                    pelaajat.Add(new Pelaaja(textBox.Text, textBox1.Text, seura, int.Parse(textBox2.Text)));
                
                }

                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }

            }

        }

    }
}


               
       
    






   