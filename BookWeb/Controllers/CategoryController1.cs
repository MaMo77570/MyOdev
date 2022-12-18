using Book.DataAccess;
using Book.DataAccess.Repository.IRepository;
using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Controllers
{

    public class CategoryController1 : Controller
    {

        private readonly  ICategoryRepository _db;

        public CategoryController1(ICategoryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
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
                _db.Add(obj);
                _db.Save();
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
            var categoryFromDbFirst = _db.GetFirstOrDefault(u => u.Name=="id");

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
                _db.Update(obj);
                _db.Save();
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
            //var categoryFormDbFirst = _db.Categories.Find(id);
            var categoryFormDbFirst= _db.GetFirstOrDefault(u => u.Name == "id");

            if (categoryFormDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFormDbFirst);
        }

        //Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u.Name == "id");
            if (id == null)
            {
                return NotFound();
            }
            _db.Remove(obj);   // maybe we should remove Remove(obj)
                _db.Save();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
            
        }

    }
}

