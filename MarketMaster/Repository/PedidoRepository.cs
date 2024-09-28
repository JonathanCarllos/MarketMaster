using MarketMaster.Context;
using MarketMaster.Models;
using MarketMaster.Repository.Interfaces;

namespace MarketMaster.Repository
{
    public class PedidoRepository : IPerdidoRepository
    {
        private readonly AppDbContext _context;
        private readonly CarrinhoAddCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext context, CarrinhoAddCompra carrinhoCompra)
        {
            _context = context;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            var carrinhoDeCompras = _carrinhoCompra.carrinhoCompras;

            foreach (var item in carrinhoDeCompras) 
            {
                var pedidoDetalhado = new PedidoDetalhe()
                {
                    Quantidade = item.Quantidade,
                    ProdutoId = item.Id,
                    PedidoId = pedido.PedidoId,
                    Preco = item.Produto.Preco
                };

                _context.PedidoDetalhes.Add(pedidoDetalhado);
            }
            _context.SaveChanges();
        }
    }
}
