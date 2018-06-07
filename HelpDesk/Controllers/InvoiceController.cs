using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Data;
using HelpDesk.Models;
using HelpDesk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelpDesk.Controllers
{
    public class InvoiceController : Controller
    {
        private ApplicationDbContext context;

        public InvoiceController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Invoices> invoice = context.Invoices.Include(c => c.Customer).ToList();
            return View(invoice);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddInvoicesViewModel addInvoicesViewModel)      
        {
            

            if (ModelState.IsValid)
            {
                // Add the new user to my existing users
                IList<Tickets> tickets = context.Tickets.Include(c => c.ID).ToList();

               
        
                return Redirect("/Ticket");
            }
            return View(addInvoicesViewModel);
        }
    }
}
