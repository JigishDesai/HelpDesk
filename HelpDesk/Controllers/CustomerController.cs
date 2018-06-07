using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelpDesk.Data;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;
using HelpDesk.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelpDesk.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;

        public CustomerController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Customers> customer = context.Customer.ToList();

            return View(customer);
        }
        public IActionResult Add()
        {
            AddCustomerViewModel addCustomerViewModel = new AddCustomerViewModel();
            return View(addCustomerViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCustomerViewModel addCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new customer to my existing customers
                Customers newCustomer = new Customers
                {
                    Name = addCustomerViewModel.Name,
                    Address = addCustomerViewModel.Address,
                    Phone = addCustomerViewModel.Phone,
                    Email = addCustomerViewModel.Email
                };

                context.Customer.Add(newCustomer);
                context.SaveChanges();

                return Redirect("/Customer");
            }

            return View(addCustomerViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.customers = context.Customer.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] customerIds)
        {
            foreach (int customerId in customerIds)
            {
                Customers theCustomer = context.Customer.Single(c => c.ID == customerId);
                context.Customer.Remove(theCustomer);
            }

            context.SaveChanges();

            return Redirect("/Customer");
        }


    }
}
