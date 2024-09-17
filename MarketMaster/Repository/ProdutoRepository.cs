using MarketMaster.Context;
using MarketMaster.Models;
using MarketMaster.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketMaster.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> Produtos => _context.Produtos.Include(c => c.Categoria);

        public IEnumerable<Produto> ProdutosFavoritos => _context.Produtos
            .Where(p => p.ProdutoDestaque)
            .Include(c => c.Categoria);

        public Produto GetProdutoById(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }
    }
}
