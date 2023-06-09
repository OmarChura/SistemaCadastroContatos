﻿using SistemaCadastro.Enums;
using SistemaCadastro.Helper;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastro.Models
{
    public class UsuarioModel
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

        [Required(ErrorMessage = "Digite a Senha do usúario")]
        public string Senha { get; set; }
        
        public DateTime DateCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public virtual List<ContatoModel> Contatos { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            {
                Senha = novaSenha.GerarHash();
                return Senha;
            }
        }
    }
}
