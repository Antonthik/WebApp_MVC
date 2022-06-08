using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Models;

namespace WebApp_MVC.Controllers
{
    public class GoodsController : Controller
    {
        private Catalog _catalog;
        public GoodsController(Catalog catalog)
        {
            _catalog = catalog;
        }

        [HttpPost]
        public IActionResult Goods([FromForm] Good model)
        {
         //_catalog.Goods.Add(model);
           _catalog.Add(model);            
            return View();
        }


        [HttpGet]
        public IActionResult Goods()
        {
            return View(_catalog);
        }
    }
}
