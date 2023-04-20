using Azure.Core.Serialization;
using SistemaCadastro.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemaCadastro.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public Sessao(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valor = JsonSerializer.Serialize(usuario);
            _httpcontextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpcontextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }

        public UsuarioModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpcontextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");
            
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
        }
    }
}
