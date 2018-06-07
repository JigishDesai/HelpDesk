using HelpDesk.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.ViewModels
{
    public class AddTicketViewModel
    {
        public float Hours { get; set; }       
        public string Comments { get; set; }
        public int CustomerID { get; set; }
        
        public List<SelectListItem> Customer { get; set; }
        
        public AddTicketViewModel()
        {

        }
        public AddTicketViewModel(IEnumerable<Customers> customers)
        {
            
            Customer = new List<SelectListItem>();

            foreach (var customer in customers)
            {
                Customer.Add(new SelectListItem
                {
                    Value = customer.ID.ToString(),
                    Text = customer.Name.ToString(),
                });
            }                
        }       
    }
}
