using Book.DataAccess;
using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Controllers
{

    public class CategoryController1 : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //Create
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DiaplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot Exatly Match The Name.");
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




        //Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var categoryFormDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Name=="id");

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
           
            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DiaplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot Exatly Match The Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFormDb = _db.Categories.Find(id);

            if (categoryFormDb == null)
            {
                return NotFound();
            }

            return View(categoryFormDb);
        }

        //Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (id == null)
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

