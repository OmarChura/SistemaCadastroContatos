using SistemaCadastro.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastro.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do usúario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login do usúario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do usúario")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Selecione o Perfil do usúario")]
        public PerfilEnum? Perfil { get; set; }
    }
}

