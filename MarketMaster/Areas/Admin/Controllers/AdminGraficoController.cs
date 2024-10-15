using MarketMaster.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;


namespace Lanchonete.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficosVendasServices _graficoVendas;

        public AdminGraficoController(GraficosVendasServices graficoVendas)
        {
            _graficoVendas = graficoVendas ?? throw
                new ArgumentNullException(nameof(graficoVendas));
        }

        public JsonResult VendasProdutos(int dias)
        {
            var VendasTotais = _graficoVendas.GetVendasProdutos(dias);
            return Json(VendasTotais);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}