using System.ComponentModel.DataAnnotations;

namespace MarketMaster.Models
{
    public class CarrinhoCompra
    {
        public int Id { get; set; }
        public Produto? Produto { get; set; }
        public int Quantidade { get; set; }

        [StringLength(200)]
        public string? CarrinhoId { get; set; }
    }
}
