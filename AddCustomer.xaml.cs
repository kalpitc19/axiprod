using Axiprod.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        private string connectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public AddCustomer()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        }

        private void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customer (CUST_NO, Name, NA1, NA2, NA3, SALESMAN, EMAIL, SIC, TERR_CODE, STATUS, TAX_CODE,ACCT_BAL,DISCOUNT) " +
                               "VALUES (@Cust_no,@Name, @NA1, @NA2, @NA3, @Salesman, @Email, @SIC, @TerrCode, @Status, @TaxCode, @Acc,@dis)";
                string getLastCustomerId = "SELECT TOP 1 CUST_NO FROM Customer ORDER BY CUST_NO DESC";
                int lastCustId = 0;
                using (SqlCommand com = new SqlCommand(getLastCustomerId, con))
                {
                    con.Open();
                    object result = com.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        lastCustId = Convert.ToInt32(result);
                    }
                    con.Close();
                }
                    using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.AddWithValue("@Cust_no", lastCustId+1);
                    com.Parameters.AddWithValue("@Name", customerName.Text);
                    com.Parameters.AddWithValue("@NA1", address1.Text);
                    com.Parameters.AddWithValue("@NA2", address2.Text);
                    com.Parameters.AddWithValue("@NA3", address3.Text);
                    com.Parameters.AddWithValue("@Salesman", salesMan.Text);
                    com.Parameters.AddWithValue("@Email", email.Text);
                    com.Parameters.AddWithValue("@SIC", sicCode.Text);
                    com.Parameters.AddWithValue("@TerrCode", territory.Text);
                    com.Parameters.AddWithValue("@Status", status.Text);
                    com.Parameters.AddWithValue("@TaxCode", taxId.Text);
                    com.Parameters.AddWithValue("@Acc", 0f);
                    com.Parameters.AddWithValue("@dis", double.Parse(discount.Text));
                    con.Open();
                    com.ExecuteNonQuery();
                }
            }


        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
