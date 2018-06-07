using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace HelpDesk.ViewModels
{
    public class AddCustomerViewModel
    {
        public string Name { get; set; }                
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<SelectListItem> Categories { get; set; }


        /* public AddCheeseViewModel()
        {

        }
        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {

            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name.ToString(),
                });
            } 

        
        } */

    }
}
