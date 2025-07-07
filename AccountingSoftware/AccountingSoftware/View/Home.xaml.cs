using System;
using System.Collections;
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

            //Add Stack Color
            SolidColorBrush color1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#222D32"));
            stackLeft.Background = color1;

            //Admin Panel
            SolidColorBrush color2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1A2226"));
            stackRight.Background = color2;
        }

        private void addAccount_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddAccount(_mainFrame));
        }

        private void viewAccount_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowAccounts(_mainFrame));
        }

        private void journalEntry_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new View.JournalEntry(_mainFrame));
        }
        private void home_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Home(_mainFrame));
        }
    }
}
