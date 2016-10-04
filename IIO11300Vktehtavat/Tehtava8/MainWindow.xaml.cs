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
            //textBox5.PasswordChar = '*';
            //textBox5.PasswordChar = '*';
            GetData();


        }
    private void GetData()
    {
      try
      {
        using (SqlConnection conn = 
          new SqlConnection(Tehtava8.Properties.Settings.(VK8Customers.V8)))
                {                       // TOIMII ??? !!!Settings.Default.ConnectionSt
                                        //yhteys
                                        //dataadapter
                                        //string sql = "Server = eight.labranet.jamk.fi; Database = Viini; User = koodari; Password = koodari13";
                                        //string sql = "SELECT asioid, lastname, firstname, date FROM presences WHERE asioid = 'salesa'";
                                        /*SELECT* FROM Customers;
                                        Try it Yourself »*/

                    string sql = "SELECT Viini WHERE User=koodari";
          SqlDataAdapter da = new SqlDataAdapter(sql, conn);
          DataTable dt = new DataTable();
                    //dt. = "kissa";//       da.Fill(dt);



                                  //sidotaan datatable UI-kontrolliin
                                  //dataGrid.DataContext = dt;
                                  /*dataGrid.DataSource(dt);*/
                                  /*sda.Fill(dt);
                                  dataGridView1.DataSource = dt;*/
                    //dt.Columns.Add("First Name");
                    da.Fill(dt);
                    dt.Rows.Add("joooop1");

                    /*    dt = "CREATE DATABASE MyDatabase ON PRIMARY " +
            "(NAME = MyDatabase_Data, " +
            "FILENAME = 'C:\\MyDatabaseData.mdf', " +
            "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            "LOG ON (NAME = MyDatabase_Log, " +
            "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
            "SIZE = 1MB, " +
            "MAXSIZE = 5MB, " +
            "FILEGROWTH = 10%)";

    */
                    //table.Rows.Add(25, "Indocin", "David", DateTime.Now);

                    //sidotaan datatable UI-kontrolliin
                    dataGrid.DataContext = dt;
                    //koo = DBDemoxOy.GetDataSimple();
                    //GridView1.DataSource = dt;
                    //GridView1.DataBind();

                    /*        DataTable dt = new DataTable();
                            dt = (DataTable)Session["userdata"];*/
//                    listBox.Items.Add(dt.ToString());//your cloumn name;



                   /* < asp:TextBox ID = "TextBox1" runat = "server" Height = "31px" Width = "142px" ></ asp:TextBox >
           
                   < asp:Button ID = "Button1" runat = "server" OnClick = "Button1_Click" Text = "Button" />
                  
                          < asp:Label ID = "lblUserName" runat = "server" />
                     
                             < asp:GridView ID = "GridView1" runat = "server" >
                        
                                </ asp:GridView >*/
                   conn.Close();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }    }
  }
}
