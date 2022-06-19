using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Models;

namespace WebApp_MVC.Controllers
{
    public class GoodsController : Controller
    {
        //private Catalog _catalog;
        private Catalog _catalog;
        private ILogger<GoodsController> _logger;
        public GoodsController(Catalog catalog, ILogger<GoodsController> logger)
        {
            _catalog = catalog;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Goods([FromForm] Good model)
        {
         //_catalog.Goods.Add(model);
           _catalog.Add(model);
           _logger.LogInformation($"Добавлены данные : Id {model.Id} Name {model.Name} Discr{model.Discription}");//элемент логирования

            return View();
        }


        [HttpGet]
        public IActionResult Goods()
        {
            return View(_catalog);
        }
    }
}
