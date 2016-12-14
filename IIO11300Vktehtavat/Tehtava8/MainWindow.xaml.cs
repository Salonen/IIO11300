/*using System;
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

namespace Tehtava8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}*/

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

namespace Tehtava8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataTable dt;
        //DataView dv;
        DataTable dt = new DataTable();

        public MainWindow()
        {


            InitializeComponent();
            //textBox5.PasswordChar = '*';
            //textBox5.PasswordChar = '*';
            //dt.Rows.Add("joooop1");
            // textBox.Text = "kkoko";//dt.Rows.ToString();
            GetData();


        }
        private void GetData()
        {
            try
            {
                using (SqlConnection conn =
                  new SqlConnection("Server=eight.labranet.jamk.fi;Database=Viini;User=koodari;Password="))
                                                                                            // salasana poistettu
                {
                    string sql = "SELECT * FROM vCustomers";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dt.Clear();

                    da.Fill(dt);




                    dataGrid.DataContext = dt;

                    listBox.DisplayMemberPath = "Lastname";

                    listBox.ItemsSource = dt.DefaultView;


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

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                /*string l, d;

                //l = listBox[0];
                var text = (listBox.SelectedItem as DataRowView)["Lastname"].ToString();
                l = text;

                for (int i = 0; i < dt.Rows.Count; i++) // Kokeile // listBox.Items.Count
                {
                    d = dt.Rows[i][0].ToString();
                    if (d == l)
                    {

                        textBox.Text = l;
                        textBox1.Text = dt.Rows[i][1].ToString();
                        textBox2.Text = dt.Rows[i][2].ToString();
                        textBox3.Text = dt.Rows[i][3].ToString();
                    }
                }*/
                int i = listBox.SelectedIndex;
                textBox.Text = dt.Rows[i][0].ToString();
                textBox1.Text = dt.Rows[i][1].ToString();
                textBox2.Text = dt.Rows[i][2].ToString();
                textBox3.Text = dt.Rows[i][3].ToString();

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

