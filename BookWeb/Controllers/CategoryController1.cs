using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Controllers;

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

    //GET
    public IActionResult Create()
    {
        
        return View();
    }

    //POST
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


    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id==0)
        {
            return NotFound();
        }
        var categoryFormDb = _db.Categories.Find(id);
        //var categoryFormDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
       // var categoryFormDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        
        if (categoryFormDb == null)
        {
            return NotFound();
        }

        return View(categoryFormDb);
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
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }











}

