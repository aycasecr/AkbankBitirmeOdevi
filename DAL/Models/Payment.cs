using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Payment
    {
        public int Id { get; set; }
        public string DuesAmount { get; set; }
        public string InvoiceAmount { get; set; }
        public string Status { get; set; }
    }
}
