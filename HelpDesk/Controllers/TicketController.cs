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
    public class TicketController : Controller
    {
        private ApplicationDbContext context;

        public TicketController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Tickets> ticket = context.Tickets.Include(c => c.Customer).ToList();

            return View(ticket);
        }

        public IActionResult Add()
        {
            AddTicketViewModel addTicketViewModel = new AddTicketViewModel(context.Customer.ToList());
            return View(addTicketViewModel);
        }

        public IActionResult Invoice()
        {
            IList<Tickets> ticket = context.Tickets.Include(c => c.Customer).ToList();

            return View(ticket);
        }

        [HttpPost]
        public IActionResult Add(AddTicketViewModel addTicketViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new user to my existing users
                Customers newCustomer = context.Customer.Single(c => c.ID == addTicketViewModel.CustomerID);
                Tickets newTicket = new Tickets
                {
                    Hours = addTicketViewModel.Hours,
                    Comments = addTicketViewModel.Comments,
                    Invoiced = "N",
                    AmountInvoiced = (100 * addTicketViewModel.Hours),
                    CustomerID = addTicketViewModel.CustomerID
                    
                };

                context.Tickets.Add(newTicket);                               
                context.SaveChanges();

                return Redirect("/Ticket");
            }

            return View(addTicketViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.tickets = context.Tickets.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] ticketIds)
        {
            foreach (int ticketId in ticketIds)
            {
                Tickets theTicket = context.Tickets.Single(c => c.ID == ticketId);
                context.Tickets.Remove(theTicket);
            }

            context.SaveChanges();

            return Redirect("/Tickets");
        }

    }
}
