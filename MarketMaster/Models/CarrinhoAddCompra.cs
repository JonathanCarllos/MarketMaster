using MarketMaster.Context;
using Microsoft.EntityFrameworkCore;

namespace MarketMaster.Models
{
    public class CarrinhoAddCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoAddCompra(AppDbContext context)
        {
            _context = context;
        }

        public string? CarrinhoAddCompraId { get; set; }
        public List<CarrinhoCompra>? carrinhoCompras { get; set; }

        public static CarrinhoAddCompra GetCarrinho(IServiceProvider service)
        {
            ISession session =
                service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDbContext>();

            string carrinhoId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            session.SetString("Id", carrinhoId);

            return new CarrinhoAddCompra(context)
            {
                CarrinhoAddCompraId = carrinhoId,
            };
        }

        public void AdicionandoAoCarrinho(Produto produto)
        {
            var carrinhoCompra = _context.CarrinhoCompras.SingleOrDefault(p => p.Produto.Id == produto.Id
              && CarrinhoAddCompraId == CarrinhoAddCompraId
            );


            if (carrinhoCompra == null)
            {
                carrinhoCompra = new CarrinhoCompra
                {
                    CarrinhoId = CarrinhoAddCompraId,
                    Produto = produto,
                    Quantidade = 1
                };

                _context.CarrinhoCompras.Add(carrinhoCompra);
            }
            else
            {
                carrinhoCompra.Quantidade++;
            }

            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Produto produto)
        {
            var carrinhoCompra = _context.CarrinhoCompras.SingleOrDefault(
                p => p.Produto.Id == produto.Id
                && CarrinhoAddCompraId == CarrinhoAddCompraId
            );

            var quantidadeLocal = 0;

            if (carrinhoCompra != null)
            {
                if (carrinhoCompra.Quantidade > 1)
                {
                    carrinhoCompra.Quantidade--;
                    quantidadeLocal = carrinhoCompra.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompras.Remove(carrinhoCompra);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompra> GetCarrinhoCompras()
        {
            return carrinhoCompras ??
                (carrinhoCompras = _context.CarrinhoCompras
                .Where(c => c.CarrinhoId == CarrinhoAddCompraId)
                .Include(c => c.Produto)
                .ToList()
                );
        }

        public void LimparCarrinho()
        {
            var carrinhoCompra = _context.CarrinhoCompras
                .Where(carrinho => carrinho.CarrinhoId == CarrinhoAddCompraId);
            _context.CarrinhoCompras.RemoveRange(carrinhoCompra);
            _context.SaveChanges();
        }

        public decimal Somar()
        {
            var total = _context.CarrinhoCompras
                .Where(c => c.CarrinhoId == CarrinhoAddCompraId)
                .Select(c => c.Produto.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
