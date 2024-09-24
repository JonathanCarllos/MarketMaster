using System.ComponentModel.DataAnnotations;

namespace MarketMaster.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; } // Identificador único da categoria

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da categoria deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; } // Nome da categoria

        [StringLength(500, ErrorMessage = "A descrição da categoria deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; } // Descrição da categoria

        public virtual ICollection<Produto>? Produtos { get; set; } // Produtos que pertencem à categoria
    }
}
