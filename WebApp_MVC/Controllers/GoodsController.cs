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
        public IActionResult Goods([FromForm] Good model, CancellationToken cancellationToken)
        {
            //_catalog.Goods.Add(model);
            //var test = new CansellationTokenExemple();
            //test.DoHevyJob(cts.Token);
           _catalog.Add(model, cancellationToken);
           _logger.LogInformation($"Добавлены данные : Id {model.Id} Name {model.Name} Discr{model.Discription}");//элемент логирования

            return View();
        }
        /// <summary>
        /// Прменение токена прерывания
        /// Запрос можно прервать не дожидаясь окончания
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("CancelQ")]
        public IActionResult CancelQuery([FromQuery] string text, CancellationToken cancellationToken)
        {
            var test = new CansellationTokenExemple();
            test.DoHevyJob(cancellationToken);
            //var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            //cts.Cancel();
            return View();
        }


        [HttpGet]
        public IActionResult Goods()
        {
            return View(_catalog);
        }
    }
}
