using Axiprod.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
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

namespace Axiprod
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private string connectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public HomePage()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            DataContext = new MainViewModel(connectionString);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Window.GetWindow(this).Close();
            main.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Window.GetWindow(this).Close();
            main.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            add_customer.Visibility = Visibility.Collapsed;
            CustomFrame.Navigate(new AddCustomer());
        }
    }
}
