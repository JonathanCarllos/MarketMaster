using MarketMaster.Models;

namespace MarketMaster.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
