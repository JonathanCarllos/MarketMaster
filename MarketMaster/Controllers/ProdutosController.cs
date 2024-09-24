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
                categoriaAtual = categoria;

                produtos = categoria.ToLower() switch
                {
                    "celular" => _produtoRepository.Produtos.Where(l => l.Categoria.Nome.Equals("Celular")).OrderBy(l => l.Nome),
                    "eletrodoméstico" => _produtoRepository.Produtos.Where(l => l.Categoria.Nome.Equals("Eletrodoméstico")).OrderBy(l => l.Nome),
                    "informática e acessórios" => _produtoRepository.Produtos.Where(l => l.Categoria.Nome.Equals("Informática e Acessórios")).OrderBy(l => l.Nome),
                    _ => _produtoRepository.Produtos.OrderBy(p => p.Id) 
                };
            }

            var produtoVM = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };

            return View(produtoVM);
        }

    }
}
