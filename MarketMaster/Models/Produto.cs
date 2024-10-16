using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketMaster.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; } // Identificador único do produto

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; } // Nome do produto

        [StringLength(500)]
        [Display(Name ="Descrição")]
        public string? Descricao { get; set; } // Descrição do produto   

        [StringLength(100)]
        public string? Marca { get; set; } // Marca do produto

        [StringLength(100)]
        public string? Modelo { get; set; } // Modelo do produto

        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 9999.99, ErrorMessage = "O preço deve estar entre 1 e 9999,99")]
        [Required]
        public decimal Preco { get; set; } // Preço do produto

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço Promoção")]
        public decimal PrecoPromocao { get; set; } // Preço do produto

        [Range(0.01, double.MaxValue, ErrorMessage = "O custo deve ser maior que zero.")]
        public decimal Custo { get; set; } // Custo de aquisição

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade em estoque deve ser zero ou positiva.")]
        [Display(Name = "Quantidade em Estoque")]
        public int QuantidadeEmEstoque { get; set; } // Quantidade em estoque   

        [StringLength(100)]
        public string? Fornecedor { get; set; } // Nome do fornecedor


        [Display(Name = "URL da Imagem")]
        public string? ImagemUrl { get; set; } // URL para a imagem do produto

        [Display(Name = "Imagem Thumblenail URL")]
        public string? ImagemThumblenailUrl { get; set; } //url da imagem em miniatura

        [Range(0.0, double.MaxValue, ErrorMessage = "O peso deve ser maior ou igual a zero.")]
        public decimal Peso { get; set; } // Peso do produto

        [Range(0.0, double.MaxValue, ErrorMessage = "A altura deve ser maior ou igual a zero.")]
        public decimal Altura { get; set; } // Altura do produto

        [Range(0.0, double.MaxValue, ErrorMessage = "A largura deve ser maior ou igual a zero.")]
        public decimal Largura { get; set; } // Largura do produto

        [Range(0.0, double.MaxValue, ErrorMessage = "A profundidade deve ser maior ou igual a zero.")]
        public decimal Profundidade { get; set; } // Profundidade do produto

        [Required]
        public bool Ativo { get; set; } // Status do produto (ativo/inativo)

        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeAdicao { get; set; } = DateTime.Now; // Data de adição do produto     

        [Display(Name = "Produto em Destaque")]
        public bool ProdutoDestaque {  get; set; } //produto em destaque


        [Display(Name = "Produto em Promoção")]
        public bool ProdutoPromocao { get; set; } //produto em destaque

        public int CategoriaId { get; set; } //chave estrangeira

        public virtual Categoria? Categoria { get; set; }
    }
}
