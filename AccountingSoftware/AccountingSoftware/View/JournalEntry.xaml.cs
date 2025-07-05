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
using AccountingSoftware.View.UserControl;
using Microsoft.Data.SqlClient;
//using Microsoft.Data.SqlClient; // Or System.Data.SqlClient for .NET Framework
using System.Configuration;
using System.Diagnostics;

namespace AccountingSoftware.View
{
    /// <summary>
    /// Interaction logic for JournalEntry.xaml
    /// </summary>
    

    public partial class JournalEntry : Page
    {
        private int debit_counter = 0;
        private int credit_counter = 0;

        private Frame _mainFrame;
        public JournalEntry(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            
            
        }

        private void addDebit_Click(object sender, RoutedEventArgs e)
        {
            Debit debit = new Debit();
            debit.Name = $"debit{debit_counter++}";
            RegisterName($"debit{debit_counter++}", debit);
            Grid.SetRow(debit, 1);
            debitStack.Children.Add(debit);
        }

        private void addCredit_Click(object sender, RoutedEventArgs e)
        {
            Credit credit = new Credit();
            credit.Name = $"credit{credit_counter++}";
            RegisterName($"credit{credit_counter++}", credit);
            Grid.SetRow(credit, 1);
            creditStack.Children.Add(credit);
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AccountingDatabase.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //Debit Stack Journal Entries
                for (int i = 0; i < debit_counter; i++)
                {
                    var control = (Debit) this.FindName($"debit{i}");
                    if (control != null) {

                        //Insert into JournalEntries table
                        string insertQuery = "INSERT INTO JournalEntries ( name, nature, amount) VALUES ( @name, @nature, @amount)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", control.account.Text);
                            cmd.Parameters.AddWithValue("@nature", "debit");
                            cmd.Parameters.AddWithValue("@amount", control.amount.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();

                        }

                        //Get the amount of the account
                        string selectQuesry = "SELECT amount FROM Account WHERE name = @name";
                        double amount = 0;
                        using (SqlCommand cmd = new SqlCommand(selectQuesry, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", control.account.Text);

                            object value = cmd.ExecuteScalar();

                            amount = Convert.ToDouble(value);
                            

                        }

                        //Update the amount of the account
                        string updateQuery = "UPDATE Account SET amount=@amount WHERE name = @account";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@amount", double.Parse(control.amount.Text) + amount );
                            cmd.Parameters.AddWithValue("@account", control.account.Text);
                           
                            int rowsAffected = cmd.ExecuteNonQuery();

                        }
                    }
                }

                //Loop through credit stack 
                for (int i = 0; i < credit_counter; i++)
                {
                    var control = (Credit)this.FindName($"credit{i}");
                    
                    if (control != null)
                    {

                        //insert entry
                        string insertQuery = "INSERT INTO JournalEntries ( name, nature, amount) VALUES ( @name, @nature, @amount)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", control.account.Text);
                            cmd.Parameters.AddWithValue("@nature", "debit");
                            cmd.Parameters.AddWithValue("@amount", control.amount.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();

                        }



                        string selectQuesry = "SELECT amount FROM Account WHERE name = @name";
                        double amount = 0;
                        using (SqlCommand cmd = new SqlCommand(selectQuesry, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", control.account.Text);

                            object value = cmd.ExecuteScalar();

                            amount = Convert.ToDouble(value);

                        }
                        string updateQuery = "UPDATE Account SET amount=@amount WHERE name = @account";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@amount", double.Parse(control.amount.Text) + amount);
                            cmd.Parameters.AddWithValue("@account", control.account.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();

                        }
                    }
                }
            }
            _mainFrame.Navigate(new Home(_mainFrame));
        }

        
    }
}
