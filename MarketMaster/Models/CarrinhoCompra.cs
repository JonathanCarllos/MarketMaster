using MarketMaster.Context;
using Microsoft.EntityFrameworkCore;

namespace MarketMaster.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //definindo sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtendo um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtendo ou gerando o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribuindo o Id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido e/ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Produto produto)
        {
            var carrinhoCompraItem = _context.CarrinhoCompras.SingleOrDefault(
                c => c.Produto.Id == produto.Id && c.CarrinhoCompraId == CarrinhoCompraId
                );

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Produto = produto,
                    Quantidade = 1
                };
                _context.CarrinhoCompras.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Produto produto)
        {
            var carrinhoCompraItem = _context.CarrinhoCompras.SingleOrDefault(
                c => c.Produto.Id == produto.Id && c.CarrinhoCompraId == CarrinhoCompraId
                );

            var quantidadeLocal = 0;

            if (carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
                quantidadeLocal = carrinhoCompraItem.Quantidade;
            }
            else
            {
                _context.CarrinhoCompras.Remove(carrinhoCompraItem);
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCompraItems()
        {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems = _context.CarrinhoCompras
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(s => s.Produto)
                .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompras
                .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompras.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompras
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Produto.Preco * c.Quantidade).Sum();

            return total;
        }
    }
}