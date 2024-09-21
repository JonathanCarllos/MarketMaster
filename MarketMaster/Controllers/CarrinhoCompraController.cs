using MarketMaster.Models;
using MarketMaster.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketMaster.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoAddCompra _carrinhoAddCompra;

        public CarrinhoCompraController(IProdutoRepository produtoRepository, CarrinhoAddCompra carrinhoAddCompra)
        {
            _produtoRepository = produtoRepository;
            _carrinhoAddCompra = carrinhoAddCompra;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
