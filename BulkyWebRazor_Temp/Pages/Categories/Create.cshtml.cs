using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties] // It will bind all the properties 
	public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //[BindProperty] It will bind  the property  only particular
        public Category Category{ get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        
        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category Created Succesfully";
            return RedirectToPage("Index");
        }
    }
}
