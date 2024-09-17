using MarketMaster.Context;
using MarketMaster.Models;
using MarketMaster.Repository.Interfaces;

namespace MarketMaster.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
