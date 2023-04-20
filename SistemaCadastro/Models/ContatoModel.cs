using System.ComponentModel.DataAnnotations;

namespace SistemaCadastro.Models
{
    public class ContatoModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do contato")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "Celular invalido")]
        public string Celular { get; set; }

    }
}
