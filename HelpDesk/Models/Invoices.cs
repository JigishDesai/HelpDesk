using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HelpDesk.Models
{
    public class Invoices
                
    {        
        public int ID { get; set; }         
        public float InvoiceHours { get; set; }
        public float Amount { get; set; }

        public int CustomerID { get; set; }
        public Customers Customer { get; set; }

        public int TicketID { get; set; }
        public Tickets Tickets { get; set; }
        
    }        
}
