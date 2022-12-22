using Book.DataAccess;
using Book.DataAccess.Repository.IRepository;
using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Areas.Admin.Controllers;
[Area("Admin")]

    public class CategoryController1 : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        //private readonly ApplicationDbContext _db;

        public CategoryController1(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    /*    public CategoryController1(ApplicationDbContext db)
    {
        _db = db;
    } */
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
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
        var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id==id);

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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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
            var categoryFormDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

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
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (id == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);   // maybe we should remove Remove(obj)
            _unitOfWork.Save();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

        }

    }


