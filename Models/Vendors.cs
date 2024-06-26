using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Axiprod.Models
{
    public class Vendors
    {
        public Byte ACCT_NO {  get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string ADDR1 { get; set; }
        public string ADDR2 { get; set; }
        public string ADDR3 { get; set; }
        public long? PHONE { get; set; }
        public string CONTACT { get; set; }
        public string TYPE { get; set; }
    }
}
