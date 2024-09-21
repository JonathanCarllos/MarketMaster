using MarketMaster.Models;
using MarketMaster.Repository.Interfaces;
using MarketMaster.ViewModels;
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
            var carrinho = _carrinhoAddCompra.GetCarrinhoCompras();
            _carrinhoAddCompra.carrinhoCompras = carrinho;

            var carrinhoVM = new CarrinhoCompraViewModel
            {
                CarrinhoAddCompra = _carrinhoAddCompra,
                CarrinhoTotal = _carrinhoAddCompra.Somar()
            };

            return View(carrinhoVM);
        }

        public RedirectToActionResult AdicionandoNoCarrinho(int ProdutoId)
        {
            var produtoSelecionado = _produtoRepository.Produtos.FirstOrDefault(
                p => p.Id == ProdutoId
            );

            if (produtoSelecionado != null)
            {
                _carrinhoAddCompra.AdicionandoAoCarrinho(produtoSelecionado);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemDoCarrinho(int ProdutoId)
        {
            var produtoSelecionado = _produtoRepository.Produtos.FirstOrDefault(
               p => p.Id == ProdutoId
            );

            if(produtoSelecionado != null)
            {
                _carrinhoAddCompra.RemoverDoCarrinho(produtoSelecionado);
            }

            return RedirectToAction("Index");
        }
    }
}
