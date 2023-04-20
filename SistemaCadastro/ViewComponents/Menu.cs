using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Models;
using System.Text.Json;

namespace SistemaCadastro.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult>InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            UsuarioModel usuario = JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);

            return View(usuario);
        }
    }
}
