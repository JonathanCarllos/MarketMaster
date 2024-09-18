using MarketMaster.Context;
using MarketMaster.Repository.Interfaces;
using MarketMaster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketMaster.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult List()
        {
            var produtoListVM = new ProdutoListViewModel();
            produtoListVM.Produtos = _produtoRepository.Produtos;
            produtoListVM.CategoriaAtual = "Categoria Atual";
            return View(produtoListVM);
        }
    }
}
