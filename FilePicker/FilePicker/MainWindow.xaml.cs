using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace FilePicker
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

        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "C# Source Files | =.cs";
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Title = "Please pick a CS Source file(s)";

            bool? success = openFileDialog.ShowDialog();

            if (success == true)
            {
                string path = openFileDialog.FileName;

                tbInfo.Text = path;
            }
            else { 
                
            }


        }
    }
}