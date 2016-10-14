using System;
using System.Data;  //sisältää ADO;n perusluokat
using System.Data.SqlClient; //SQL Server spesifiset luokat
//using System.Data.SqlClient;
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



namespace Tehtava9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt = new DataTable();

        public MainWindow()
        {


            InitializeComponent();
            //textBox5.PasswordChar = '*';
            //textBox5.PasswordChar = '*';
            //dt.Rows.Add("joooop1");
            // textBox.Text = "kkoko";//dt.Rows.ToString();
            GetData();

            /*toka bWin = new toka();
            bWin.Owner = this;
            bWin.Show();*/


        }
        private void GetData()
        {
            try
            {
                using (SqlConnection conn =
                  new SqlConnection("Server=;Database=;User=;Password="))
                            // Yhteystiedot poistettu
                {
                    string sql = "SELECT * FROM customer";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dt.Clear();

                    da.Fill(dt);




                    //dataGrid.DataContext = dt;
                    //dataGrid.Items.Add(dt);
                    //dataGrid.DataContext = dt.DefaultView;
                    //DataTable _simpleDataTable = new ataTable();
                    dataGrid.AutoGenerateColumns = true;
                    dataGrid.ItemsSource = dt.DefaultView;

                    /*listBox.DisplayMemberPath = "Lastname";

                    listBox.ItemsSource = dt.DefaultView;*/


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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Boolean num = true;

                for (int i = 0; i < textBox3.Text.Length; i++)
                {
                    if (!char.IsDigit(textBox3.Text[i])) num = false;
                }
                if (textBox.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && num)
                    using (var conn = new SqlConnection("Server=;Database=;User=;Password="))
                                            // Yhteystiedot poistettu
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        string sql = string.Format("INSERT INTO customer (firstname, lastname, address, zip, city) VALUES ('{0}','{1}','{2}','{3}','{4}')", textBox.Text, textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), textBox4.Text);

                        cmd.CommandText = sql;
                        var result = cmd.ExecuteNonQuery();
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
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int k = dataGrid.SelectedIndex;

                    string lastname = textBox5.Text = dt.Rows[k][2].ToString();


                    using (var conn = new SqlConnection("Server=;Database=;User=;Password="))
                                            // Yhteystiedot poistettu
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        string sql = string.Format("DELETE FROM customer WHERE lastname='{0}'", lastname); ;

                        cmd.CommandText = sql;
                        var result = cmd.ExecuteNonQuery();
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
    }
}
