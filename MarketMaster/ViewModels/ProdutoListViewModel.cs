using MarketMaster.Models;

namespace MarketMaster.ViewModels
{
    public class ProdutoListViewModel
    {
        public IEnumerable<Produto>? Produtos { get; set; }
        public string? CategoriaAtual { get; set; }

    }
}
