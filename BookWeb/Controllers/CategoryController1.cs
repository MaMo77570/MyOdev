using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Controllers
{
    public class CategoryController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
