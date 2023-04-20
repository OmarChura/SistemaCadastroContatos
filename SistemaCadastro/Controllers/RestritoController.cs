using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Filters;

namespace SistemaCadastro.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
