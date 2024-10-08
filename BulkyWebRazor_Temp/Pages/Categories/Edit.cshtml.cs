﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //[BindProperty] It will bind  the property  only particular
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {


            _db = db;
        }

        public void OnGet(int? id)

        {
            if(id != null && id!=0)
            {
                Category = _db.Categories.Find(id);

            }

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                //return View();  // because it will go to create view
                TempData["success"] = "Category Updated Succesfully";

                return RedirectToPage("Index"); // we need to go for index after creating so we used redirectToAction method

            }
            return Page();
           
        }
    }
}