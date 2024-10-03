using MarketMaster.Context;
using MarketMaster.Models;
using MarketMaster.Repository.Interfaces;

namespace MarketMaster.Repository
{
    public class PedidoRepository : IPerdidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            foreach (var carrinhoItens in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItens.Quantidade,
                    ProdutoId = carrinhoItens.Produto.Id,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItens.Produto.Preco
                };
                _appDbContext.PedidoDetalhe.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}

