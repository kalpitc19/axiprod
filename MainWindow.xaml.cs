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
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Controls.Primitives;
using System.Data;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;
using Axiprod.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Linq;
using Axiprod.ViewModels;

namespace Axiprod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        }
        public void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //login without verification
            //MainFrame.Navigate(new HomePage());
            //LoginPage.Visibility = Visibility.Collapsed;

            if (VerifyUser(txtUsername.Text, txtPassword.Password))
            {
                //MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginPage.Visibility = Visibility.Collapsed;

                //showing next page
                MainFrame.Navigate(new HomePage());
            }
            else
            {
                MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool VerifyUser(string username, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("SELECT COUNT(*) FROM security WHERE USER_ID = @username AND PASSWORD = @password", con))
                    {
                        com.Parameters.AddWithValue("@username", username);
                        com.Parameters.AddWithValue("@password", password);

                        int userCount = (int)com.ExecuteScalar();
                        return userCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}