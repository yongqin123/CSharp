﻿using Microsoft.Data.SqlClient;
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
//using Microsoft.Data.SqlClient;

namespace AccountingSoftware.View
{
    /// <summary>
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Page
    {
        private Frame _mainFrame;
        private Account _account;
        public EditAccount(Frame mainFrame, Account account)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            _account = account;
            string[] comboItems = new[] { "Asset", "Liability", "Equity" };

            type.ItemsSource = comboItems;
            name.Text = account.name;
            type.Text = account.type;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yongq\source\repos\C#\AccountingSoftware\AccountingSoftware\AccountingDatabase.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE Account SET name = @name, type = @type WHERE Id = @Id;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    //cmd.Parameters.AddWithValue("@Id", 0);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@type", type.Text);
                    cmd.Parameters.AddWithValue("@Id", _account.Id);

                    // cmd.Parameters.AddWithValue("@amount", 0);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    _mainFrame.Navigate(new ShowAccounts(_mainFrame));

                }
            }
        }
    
    }
}
