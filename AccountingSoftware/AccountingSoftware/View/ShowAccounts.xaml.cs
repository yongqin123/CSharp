using System;
using System.Collections.Generic;
using System.Data;
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
using Microsoft.Data.SqlClient;
//using Microsoft.Data.SqlClient; // Or System.Data.SqlClient for .NET Framework
using System.Configuration;
//using System.Data; // Required for DataTable


namespace AccountingSoftware.View
{
    /// <summary>
    /// Interaction logic for ShowAccounts.xaml
    /// </summary>
    public partial class ShowAccounts : Page
    {
        public ShowAccounts()
        {
            InitializeComponent();

            string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Id, Name, Age FROM Users";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    UserDataGrid.ItemsSource = dt.DefaultView;
                }
            }
        }
    }
}
