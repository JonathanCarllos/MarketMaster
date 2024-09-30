using MarketMaster.Models;
using MarketMaster.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketMaster.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPerdidoRepository _perdidoRepository;
        private readonly CarrinhoAddCompra carrinhoAddCompra;

        public PedidoController(IPerdidoRepository perdidoRepository, CarrinhoAddCompra carrinhoAddCompra)
        {
            _perdidoRepository = perdidoRepository;
            this.carrinhoAddCompra = carrinhoAddCompra;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            return View(pedido);
        }
    }
}
