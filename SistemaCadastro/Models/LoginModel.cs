using SistemaCadastro.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastro.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login do usúario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a Senha do usúario")]
        public string Senha { get; set; }
    }
}
