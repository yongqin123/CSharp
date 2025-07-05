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
using System.Configuration;
using Microsoft.Data.SqlClient;


namespace AccountingSoftware.View
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Page
    {
        private Frame _mainFrame;
        public AddAccount(Frame mainFrame)
        {
            InitializeComponent();

            _mainFrame = mainFrame; 

            string[] comboItems = new[] { "Asset","Revenue", "Expense", "Dividends" , "Liability", "Equity" };

            type.ItemsSource = comboItems;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AccountingDatabase.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string insertQuery = "INSERT INTO Account ( name, type, amount, nature) VALUES ( @name, @type, @amount, @nature)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    //cmd.Parameters.AddWithValue("@Id", 0);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@type", type.Text);
                    cmd.Parameters.AddWithValue("@amount", 0);

                    if (type.Text == "Asset" || type.Text == "Expense" || type.Text == "Dividends")
                    {
                        cmd.Parameters.AddWithValue("@nature", "debit");
                    }
                    else 
                    {
                        cmd.Parameters.AddWithValue("@nature", "credit");
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    _mainFrame.Navigate(new Home(_mainFrame));

                }
            }
        }
    }
}
