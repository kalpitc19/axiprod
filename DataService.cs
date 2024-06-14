using Axiprod.Models;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace Axiprod
{
    public class DataService
    {
        private readonly string _connectionString;

        public DataService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ObservableCollection<Customers> GetData()
        {
            var data = new ObservableCollection<Customers>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Customer", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new Customers
                            {
                                CUST_ID = reader.GetInt32(0),
                                NAME = reader.GetString(reader.GetOrdinal("NAME")),
                                NA1 = reader.GetString(reader.GetOrdinal("NA1")),
                                NA2 = reader.GetString(reader.GetOrdinal("NA2")),
                                NA3 = reader.IsDBNull(reader.GetOrdinal("NA3")) ? null : reader.GetString(reader.GetOrdinal("NA3")),
                                SIC = reader.IsDBNull(reader.GetOrdinal("SIC")) ? null : reader.GetString(reader.GetOrdinal("SIC")),
                                TAX_ID = reader.IsDBNull(reader.GetOrdinal("TAX_ID")) ? null : reader.GetString(reader.GetOrdinal("TAX_ID")),
                                TAX_STATE = reader.IsDBNull(reader.GetOrdinal("TAX_STATE")) ? null : reader.GetString(reader.GetOrdinal("TAX_STATE")),
                                TAX_CODE = reader.IsDBNull(reader.GetOrdinal("TAX_CODE")) ? null : reader.GetString(reader.GetOrdinal("TAX_CODE")),

                                //ACCT_BAL = reader.GetFloat(reader.GetOrdinal("ACCT_BAL")),
                                ACCT_BAL = reader.GetOrdinal("ACCT_BAL") == 0 ? 0d: reader.GetDouble(reader.GetOrdinal("ACCT_BAL")),
                                DISCOUNT = reader.GetOrdinal("DISCOUNT") == 0 ? 0d : reader.GetDouble(reader.GetOrdinal("DISCOUNT")),

                                TERR_CODE = reader.IsDBNull(reader.GetOrdinal("TERR_CODE")) ? null : reader.GetString(reader.GetOrdinal("TERR_CODE")),
                                SALESMAN = reader.IsDBNull(reader.GetOrdinal("SALESMAN")) ? null : reader.GetString(reader.GetOrdinal("SALESMAN")),
                                STATUS = reader.IsDBNull(reader.GetOrdinal("STATUS")) ? null : reader.GetString(reader.GetOrdinal("STATUS")),
                                EMAIL = reader.IsDBNull(reader.GetOrdinal("EMAIL")) ? null : reader.GetString(reader.GetOrdinal("EMAIL"))
                            });
                        }
                    }
                }
            }

            return data;
        }
    }
}
