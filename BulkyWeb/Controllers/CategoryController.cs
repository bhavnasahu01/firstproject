using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The displayorder canot exactly match the Name");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an Invalid value");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                //return View();  // because it will go to create view
                TempData["success"] = "Category Created Succesfully";

                return RedirectToAction("Index"); // we need to go for index after creating so we used redirectToAction method

            }
            return View();
            
        }



        public IActionResult Edit(int? id)
        {
            if (id == null  || id == 0)
            {
                return NotFound();
            }
            // three methods to find the id 
            Category? categoryFromDb = _db.Categories.Find(id);

            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u =>u.Id ==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (categoryFromDb== null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
          
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                //return View();  // because it will go to create view
                TempData["success"] = "Category Updated Succesfully";

                return RedirectToAction("Index"); // we need to go for index after creating so we used redirectToAction method

            }
            return View();

        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {

                _db.Categories.Remove(obj);
                _db.SaveChanges();

                TempData["success"] = "Category Deleted Succesfully";

                return RedirectToAction("Index"); // we need to go for index after creating so we used redirectToAction method

            }


            return View();


        }
    }
}

