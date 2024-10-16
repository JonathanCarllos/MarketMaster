using MarketMaster.Models;

namespace MarketMaster.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produto>? ProdutoSelecionados { get; set; }

        public IEnumerable<Produto>? ProdutoSelecionadosPromocao { get; set; }
    }
}
