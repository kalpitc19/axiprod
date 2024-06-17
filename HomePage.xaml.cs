using Axiprod.Models;
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

        private void Button_Click_AddJob(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewCustomer(object sender, RoutedEventArgs e)
        {
            //add_customer.Visibility = Visibility.Collapsed;

            //making FRame to come in front
            Grid.SetZIndex(CustomFrame, menulist.Children.Count);
            Grid.SetZIndex(add_customer, menulist.Children.Count-1);
            CustomFrame.Navigate(new AddCustomer());
        }

        private void TabItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //whenever tabitem is clicked-
            if (sender is TabItem tabItem)
            {
                Grid.SetZIndex(add_customer, menulist.Children.Count);
                Grid.SetZIndex(CustomFrame, menulist.Children.Count - 1);
            }
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedElement = e.EditingElement as TextBox;
            if (editedElement != null)
            {
                string newValue = editedElement.Text;

                // Get the row data
                var editedRow = (Customers)e.Row.Item;

                // Get the column that was edited
                string columnName = e.Column.Header.ToString();

                // Perform the update
                UpdateDatabase(editedRow.CUST_ID, columnName, newValue);
            }

        }
        private void UpdateDatabase(int id, string columnName, string newValue)
        {
            string updateQuery = $"UPDATE Customer SET {columnName} = @newValue WHERE CUST_NO = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@newValue", newValue);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void LoadData()
        {
            // Implementation for loading data into the DataGrid
        }
    }
}
