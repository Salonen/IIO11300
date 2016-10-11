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
                        if (pelaajat[n].Seura == comboBox.SelectedItem)
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
                        if (pelaajat[n].Seura == comboBox.SelectedItem)
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
            /*string connectionString = @"Provider=Microsoft Office 12.0 Access Database Engine OLE DB Provider;" + @"Data source= C:\Users\nearod\Desktop\ImportDB.accdb";

            string queryString = "SELECT * FROM [SQL Agent Unique ID Test Load]";
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source");
            }*/
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            




            /*using (var conn = new OleDbConnection(@"Provider=Pelaajat;Data Source=G:\c#2\IIO11300\SMLiiga.accdb")) //Microsoft.ACE.OLEDB.12.0
            using (var comm = conn.CreateCommand())
            {
                comm.CommandText = "SELECT * FROM etunimi";
                comm.CommandType = CommandType.Text;

                conn.Open();

                var returnValue = comm.ExecuteScalar();

                MessageBox.Show(returnValue.ToString());
            }*/

            //OleDbConnection connectionString = new OleDbConnection(@"Provider=Pelaajat;" + @"Data Source=G:\c#2\IIO11300\SMLiiga.accdb");

            /*string connectionString = @"Provider=Microsoft.ACE.OLEDB.14.0;" + @"Data Source=G:\c#2\IIO11300\SMLiiga.accdb";

            string queryString = "SELECT * FROM etunimi";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    /*string companyCode = reader.GetValue(0).ToString();
                    string agentId = reader.GetString(1);
                    string firstName = reader.GetString(2);
                    string lastName = reader.GetString(3);
                    string nameSuffix = reader.GetString(4);
                    string corporateName = reader.GetString(5);
                    string entityType = reader.GetString(6);
                    string obfSSN = reader.GetString(7);
                    string obfFEIN = reader.GetString(8);
                    string dummyIndicator = reader.GetString(9);*/
            // Insert code to process data.
            /*      listBox.ItemsSource = reader.GetString(1);
              }
              reader.Close();
          }




          /*object[] meta = new object[10];
          bool read;
          using (con)
              /*Microsoft.ACE.OLEDB.12.0 */
            /*{
                //con.Open();
                string loo = /*"ServerVersion: {0} \nDataSource: {1}"+*/ //con.ToString();// + con.DataSource;// + con.DataSource;

            /*OleDbCommand command = new OleDbCommand("select * from Pelaajat", con);

            //con.Open();
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read() == true)
            {
                do
                {
                    int NumberOfColums = reader.GetValues(meta);

                    for (int i = 0; i < NumberOfColums; i++)
                        listBox.ItemsSource = meta[i].ToString();

                    //Console.WriteLine();
                    read = reader.Read();
                } while (read == true);
            }
            reader.Close();*/
            /*string queryString = "SELECT OrderID, CustomerID FROM Orders";

                OracleCommand command = new OracleCommand(queryString, con);
                con.Open();
                OracleDataReader reader;
                reader = command.ExecuteReader();

                // Always call Read before accessing data.
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1));
                }

                // Always call Close when done reading.
                reader.Close();*/

            //   }
            // ToString() !!!!!!


            /*string sql = "SELECT * FROM vCustomers";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            dt.Clear();

            da.Fill(dt);




           // dataGrid.DataContext = dt;

            listBox.DisplayMemberPath = "Lastname";

            listBox.ItemsSource = dt.DefaultView;*/

            //listBox.ItemsSource = loo;


        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            /*CREATE TABLE oma(
            firstname VARCHAR(30) NOT NULL,
            lastname VARCHAR(30) NOT NULL,
            seura VARCHAR(30) NOT NULL,
            hinta INT(6) NOT NULL
            )*/

            string connStr = "server=mysql.labranet.jamk.fi;user=H8482;password=joo;";//"server=localhost;user=root;port=3306;password=mysql;"
                                                              // Älä laita salasanaa Githubbiin
            /*MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd;
            string s0;
            // autentikoi*/
            try
            {
                /*using (var conn = new MySqlConnection(connStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * ALL pelitietokoneet;";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }*/
                //string connection = "Server=localhost;Database=user_table;Uid=root;Pwd=";
                MySqlConnection dbcon = new MySqlConnection(connStr);
                DataTable dt = new DataTable();

                MySqlCommand cmd;
                dbcon.Open();

                cmd = dbcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM henkilot2";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                /*dataGrid1.DataSource = dt;
                da,taGrid1.DataBind();*/

                dataGrid1.AutoGenerateColumns = true;
                dataGrid1.ItemsSource = dt.DefaultView;




                /* conn.Open();

                 s0 = "CREATE DATABASE IF NOT EXISTS `simo`;";
                 cmd = new MySqlCommand(s0, conn);
                 cmd.ExecuteNonQuery();

                 //conn.Close();
                 //s0 = "CREATE DATABASE IF NOT EXISTS simo;"; // simo'simo`
                 s0 = "CREATE TABLE oma(firstname VARCHAR(30) NOT NULL,lastname VARCHAR(30) NOT NULL,seura VARCHAR(30) NOT NULL, hinta INT(6) NOT NULL) ";
                 cmd = new MySqlCommand(s0, conn);
                 cmd.ExecuteNonQuery(); // HUOM TÄRKEÄ*/



                //conn.Close();
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





   