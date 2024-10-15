using MarketMaster.Context;
using MarketMaster.Models;

namespace MarketMaster.Areas.Admin.Services
{
    public class GraficosVendasServices
    {
        private readonly AppDbContext context;

        public GraficosVendasServices(AppDbContext context)
        {
            this.context = context;
        }

        public List<ProdutoGrafico> GetVendasProdutos(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var produtos = (from pd in context.PedidoDetalhe
                            join l in context.Produtos on pd.ProdutoId equals l.Id
                            where pd.Pedido.PedidoEnviado >= data
                            group pd by new { pd.ProdutoId, l.Nome }
                           into g
                            select new
                            {
                                ProdutoNome = g.Key.Nome,
                                ProdutoQuantidade = g.Sum(q => q.Quantidade),
                                ProdutoValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                            });

            var lista = new List<ProdutoGrafico>();

            foreach (var item in produtos)
            {
                var produto = new ProdutoGrafico();
                produto.ProdutoNome = item.ProdutoNome;
                produto.ProdutoQuantidade = item.ProdutoQuantidade;
                produto.ProdutoTotalValor = item.ProdutoValorTotal;
                lista.Add(produto);
            }
            return lista;
        }
    }
}
