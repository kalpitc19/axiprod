using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axiprod.Models
{
    public class Jobs
    {
          public Int16 CUST_NO {  get; set; }
          public int JOB_NO {  get; set; }
          public decimal TYPE {  get; set; }
          public DateTime DATE {  get; set; }
          public string SALESMAN { get; set; }
          public Int16 SHIP_TO { get; set; }
          public string CUST_PO {  get; set; }
        
          public string NAME { get; set; }
          public string TERMS {  get; set; }
          public string TAX_ID { get; set; }
          public string INVC_CODE { get; set; }
          public string TAX_CODE {  get; set; }
          public string TAX_STATE { get; set; }
          public Byte TO { get; set; }
    }
}
