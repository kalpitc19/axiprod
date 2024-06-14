using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axiprod.Models
{
    public class Customers
    {
        public int CUST_ID { get; set; }
        public string NAME { get; set; }
        public string NA1 {  get; set; }
        public string NA2 { get; set; }
        public string NA3 { get; set; }
        public string SIC { get; set; }
        public string TAX_ID { get; set; }
        public string TAX_STATE { get; set; }
        public string TAX_CODE { get; set; }
        public double ACCT_BAL { get;set; }
        public double DISCOUNT { get;set;}
        public string TERR_CODE { get; set; }
        public string SALESMAN { get;set ;}
        public string STATUS { get; set; }
        public string EMAIL { get; set; }

    }
}
