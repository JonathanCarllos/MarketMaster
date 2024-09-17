using MarketMaster.Models;

namespace MarketMaster.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; }
        IEnumerable<Produto> ProdutosFavoritos { get; }
        Produto GetProdutoById(int id);
    }
}
