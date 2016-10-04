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
                  new SqlConnection("Server=eight.labranet.jamk.fi;Database=Viini;User=koodari;Password=koodari13"))

                {
                    string sql = "SELECT * FROM vCustomers";//"SELECT koodari, lastname, firstname FROM Viini WHERE asioid = 'koodari'";//"SELECT Viini WHERE User=koodari";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dt.Clear();
                    //dt. = "kissa";//
                    da.Fill(dt);


                    //textBox.Text = dt.Columns.ToString();/*"susus";// dt.ToString();//dt.Rows.ToString();*/

                    dataGrid.DataContext = dt;
                    //listBox.Items.Add( dt);
                    //listBox.DataSource = dt;
                    listBox.DisplayMemberPath = "Lastname";
                    ///listBox.Items.Add(dt.Rows[0][i].ToString());
                    ///
                    //listBox.Items.Clear();


                    /////listBox.DataContext=dt.Rows.ToString();

                    /*listBox.DisplayMember = dt.Columns[0].ColumnName;
                    listBox.ValueMember = dt.Columns[1].ColumnName;
                    // 2. set DataSource
                    lisbox.DataSource = dt;*/
                    listBox.ItemsSource = dt.DefaultView;
                    
                    /*for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (listBox.SelectedItem.ToString() == dt.Rows[i][0].ToString())
                        {
                            textBox.Text = dt.Rows[i][0].ToString();
                        }
                    }*/
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


            //listBox.DisplayMemberPath = "Firstname";

            /*listBox.FullRowSelect = true;

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["id"].ToString());
                item.SubItems.Add(row["name"].ToString());
                listViewEx1.Items.Add(item); //Add this row to the ListView
            }*/


            //listBox.DataContext
            //listBox.DataSource = dt;
            //listBox.DisplayMember = "";
            /*listBox1.DisplayMember = "Name";
            /*listBox1.ValueMember = "ID";
            conn.Close();




        }
  /*}
  catch (Exception ex)
  {
    MessageBox.Show(ex.Message);
  }*/
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                string l, d;

                //l = listBox[0];
                var text = (listBox.SelectedItem as DataRowView)["Lastname"].ToString();
                l = text;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    d = dt.Rows[i][0].ToString();
                    if (d == l)
                    {
                        /*(listBox.SelectedItem.ToString())*//*((ListBoxItem)listBox.SelectedItem).Content.ToString()*//*(string)listBox.SelectedItem == (string)dt.Rows[i][0])*/
                                                                                                                       //{
                        textBox.Text = l;
                        //(dt.Rows[i][0].ToString());
                        //i = dt.Rows.Count + 1;

                    }
                }
            
        }
    }
}

