using MarketMaster.Models;
using MarketMaster.Repository.Interfaces;
using MarketMaster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public HomeController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {

                ProdutoSelecionados = _produtoRepository.ProdutosFavoritos
            };

            return View(homeViewModel);
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
