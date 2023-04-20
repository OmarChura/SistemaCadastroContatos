using System.ComponentModel.DataAnnotations;

namespace SistemaCadastro.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login do usúario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do usúario")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        public string Email { get; set; }
    }
}
