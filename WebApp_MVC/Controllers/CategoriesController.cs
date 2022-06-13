using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Models;

namespace WebApp_MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private ThreadSafeCatalog _catalog;
        public CategoriesController(Catalog catalog)
        {
            _catalog = catalog;
        }


        [HttpGet]
        public IActionResult Categories()
        {
            return View(_catalog);
        }
    }
}
