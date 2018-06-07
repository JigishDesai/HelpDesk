using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Tickets
    {
        public int ID { get; set; }
        public float Hours { get; set; }
        public string Comments { get; set; }
        public string Invoiced { get; set; }
        public float AmountInvoiced { get; set; }
               
        public int CustomerID { get; set; }
        public Customers Customer { get; set; }
    }
}
