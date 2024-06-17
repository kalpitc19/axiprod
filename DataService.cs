using Axiprod.Models;
using HandyControl.Tools.Extension;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace Axiprod
{
    public class DataService
    {
        private readonly string _connectionString;

        public DataService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ObservableCollection<Customers> GetAllCustomersData()
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
                                ACCT_BAL = reader.GetOrdinal("ACCT_BAL") == 0 ? 0d : reader.GetDouble(reader.GetOrdinal("ACCT_BAL")),
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

        public ObservableCollection<Vendors> GetAllVendorsData()
        {
            var data = new ObservableCollection<Vendors>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM dbo.Vendor", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new Vendors
                            {
                                ACCT_NO = reader.GetByte(0),
                                CODE = reader.GetString(reader.GetOrdinal("CODE")),
                                NAME = reader.GetString(reader.GetOrdinal("NAME")),

                                ADDR1 = reader.IsDBNull(reader.GetOrdinal("ADDR1")) ? null :  reader.GetString(reader.GetOrdinal("ADDR1")),
                                ADDR2 = reader.IsDBNull(reader.GetOrdinal("ADDR2")) ? null :  reader.GetString(reader.GetOrdinal("ADDR2")),
                                ADDR3 = reader.IsDBNull(reader.GetOrdinal("ADDR3")) ? null : reader.GetString(reader.GetOrdinal("ADDR3")),
                                PHONE = reader.IsDBNull(reader.GetOrdinal("PHONE")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("PHONE")),
                                CONTACT = reader.IsDBNull(reader.GetOrdinal("CONTACT")) ? null : reader.GetString(reader.GetOrdinal("CONTACT")),
                                TYPE = reader.IsDBNull(reader.GetOrdinal("TYPE")) ? null : reader.GetString(reader.GetOrdinal("TYPE")),

                            });
                        }
                    }
                }
            }

            return data;
        }
        public ObservableCollection<Jobs> GetAllJobsData()
        {
            var data = new ObservableCollection<Jobs>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM dbo.Job", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new Jobs
                            {
                                CUST_NO = reader.GetInt16(0),
                                JOB_NO = reader.GetInt32(reader.GetOrdinal("JOB_NO")),
                                TYPE = reader.GetDecimal(reader.GetOrdinal("TYPE")),
                                DATE = reader.GetDateTime(reader.GetOrdinal("DATE")),
                                SALESMAN= reader.GetString(reader.GetOrdinal("SALESMAN")),
                                SHIP_TO = reader.GetInt16(reader.GetOrdinal("SHIP_TO")),
                                CUST_PO = reader.GetString(reader.GetOrdinal("CUST_PO")),
                                NAME = reader.IsDBNull(reader.GetOrdinal("NAME")) ? null : reader.GetString(reader.GetOrdinal("NAME")),
                                TERMS= reader.IsDBNull(reader.GetOrdinal("TERMS")) ? null : reader.GetString(reader.GetOrdinal("TERMS")),
                                TAX_ID = reader.IsDBNull(reader.GetOrdinal("TAX_ID")) ? null : reader.GetString(reader.GetOrdinal("TAX_ID")),
                                INVC_CODE = reader.IsDBNull(reader.GetOrdinal("INVC_CODE")) ? null : reader.GetString(reader.GetOrdinal("INVC_CODE")),
                                TAX_CODE = reader.IsDBNull(reader.GetOrdinal("TAX_CODE")) ? null : reader.GetString(reader.GetOrdinal("TAX_CODE")),
                                TAX_STATE = reader.IsDBNull(reader.GetOrdinal("TAX_STATE")) ? null : reader.GetString(reader.GetOrdinal("TAX_STATE")),
                                TO= (byte)(reader.IsDBNull(reader.GetOrdinal("TO")) ? 0 : reader.GetByte(reader.GetOrdinal("TO")))
                            });
                        }
                    }
                }
            }

            return data;
        }
    }
}
