using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<Category> objCategoryList= _db.Categories;
            return View(objCategoryList);
        }
        ///////////////////////////////////////////GET
        public IActionResult Create()
        {
            
            return View();
        }

        ///////////////////////////////////////////POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DiaplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot Exatly Match The Name.");
            }

            if (ModelState.IsValid) 
            { 
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
