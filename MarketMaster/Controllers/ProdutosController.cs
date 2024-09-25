using MarketMaster.Context;
using MarketMaster.Models;
using MarketMaster.Repository.Interfaces;
using MarketMaster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MarketMaster.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.Id);
                categoriaAtual = "Todos os Produtos";
            }
            else
            {
                produtos = _produtoRepository.Produtos.Where(p => p.Categoria.Nome.Equals(categoria)).OrderBy(c => c.Nome);
                categoriaAtual = categoria;

            }

            var produtoVM = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };

            return View(produtoVM);
        }

        public IActionResult Detail(int id)
        {
            var detalhes = _produtoRepository.Produtos.FirstOrDefault(p => p.Id == id);
            return View(detalhes);
        }
    }
}
