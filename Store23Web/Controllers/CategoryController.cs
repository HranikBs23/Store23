﻿using Microsoft.AspNetCore.Mvc;
using Store23.DataAccess;
using Store23.Models;

namespace Store23Web.Controllers
{
    public class CategoryController : Controller


    {

        //Dependency 
        private readonly StoreDbContext _db;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;

        public CategoryController(StoreDbContext db , ILogger<CategoryController> logger , IWebHostEnvironment env) 
        {

            _db = db;
            _logger = logger;
            _env = env;
        }
    


      public IActionResult Index()
    {

            //retrieve categories and convert to list

            IEnumerable<Category> objCategoryList = _db.Categories;

           return View(objCategoryList);
    }

        //Get
        public IActionResult  Create () {

			
			return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Category obj )
        {
            if (obj.CategoryName == obj.DisplayOrder.ToString())
            {
				ModelState.AddModelError("CategoryName", "Category Name and Dispaly Order Cannot match exactly ");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //Get 

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0){
                return NotFound();
            }
            //var category = _db.Categories.FirstOrDefault(a => a.CategoryId ==id);
            var category = _db.Categories.Find(id);
            if (category == null) { 
            
                return NotFound();
                    }
            
            return View(category);
        }

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category editObj) {
			if (editObj.CategoryName == editObj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("CategoryName", "Category Name and Dispaly Order Cannot match exactly ");
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Update(editObj);
				_db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
				return RedirectToAction("Index");
			}

			return View(editObj);


		}


		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var deleteCategory = _db.Categories.Find(id);
			//var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
			//var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

			if (deleteCategory == null)
			{
				return NotFound();
			}

			return View(deleteCategory);
		}

		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.Categories.Remove(obj);
			_db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

		}

	}
}
