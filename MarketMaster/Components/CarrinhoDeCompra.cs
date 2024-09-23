using MarketMaster.Models;
using MarketMaster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace MarketMaster.Components
{
    public class CarrinhoDeCompra : ViewComponent
    {
        public readonly CarrinhoAddCompra _carrinhoAddCompra;

        public CarrinhoDeCompra(CarrinhoAddCompra carrinhoAddCompra)
        {
            _carrinhoAddCompra = carrinhoAddCompra;
        }

        public IViewComponentResult Invoke()
        {
            var carrinho = _carrinhoAddCompra.GetCarrinhoCompras();
            _carrinhoAddCompra.carrinhoCompras = carrinho;

            var carrinhoVM = new CarrinhoCompraViewModel
            {
                CarrinhoAddCompra = _carrinhoAddCompra,
                CarrinhoTotal = _carrinhoAddCompra.Somar()
            };

            return View(carrinhoVM);
        }
    }
}
