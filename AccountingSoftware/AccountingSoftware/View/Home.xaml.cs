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
using AccountingSoftware.View;

namespace AccountingSoftware
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private Frame _mainFrame;
        public Home(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void addAccount_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddAccount(_mainFrame));
        }

        private void viewAccount_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowAccounts(_mainFrame));
        }
    }
}
