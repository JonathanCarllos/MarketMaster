using MarketMaster.Areas.Admin.Services;
using MarketMaster.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketMaster.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly GraficosVendasServices _graficoVendas;
        private readonly AppDbContext _context;

        public AdminController(GraficosVendasServices graficoVendas, AppDbContext context)
        {
            _graficoVendas = graficoVendas ?? throw
                new ArgumentNullException(nameof(graficoVendas));
            _context = context;
        }

        public JsonResult VendasProdutos(int dias)
        {
            var VendasTotais = _graficoVendas.GetVendasProdutos(dias);
            return Json(VendasTotais);
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produtos
               .Include(p => p.Categoria) // Carrega a categoria associada
               .ToListAsync();
            return View(produtos);
        }
    }
}
