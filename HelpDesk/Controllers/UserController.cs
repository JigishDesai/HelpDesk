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
    public class UserController : Controller
    {
        private ApplicationDbContext context;

        public UserController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Users> user = context.User.ToList();

            return View(user);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new user to my existing users
                Users newUser = new Users
                {
                    Username = addUserViewModel.Username,
                    Password = addUserViewModel.Password,
                };

                context.User.Add(newUser);

                //context.Users.Add(newUser);
                context.SaveChanges();

                return Redirect("/User");
            }

            return View(addUserViewModel);
        }

        public IActionResult Remove()
        {            
            ViewBag.users = context.User.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] userIds)
        {
            foreach (int userId in userIds)
            {
                Users theUser= context.User.Single(c => c.ID == userId);
                context.User.Remove(theUser);
            }

            context.SaveChanges();

            return Redirect("/User");
        }
    }
}
