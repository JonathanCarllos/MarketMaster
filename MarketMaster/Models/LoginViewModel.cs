using System.ComponentModel.DataAnnotations;

namespace MarketMaster.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="campo Obrigatório")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name ="Lembre-me")]
        public bool RememberMe { get; set; }    
    }
}
