using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Helper;
using SistemaCadastro.Models;
using SistemaCadastro.Repositorio;

namespace SistemaCadastro.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                    alterarSenhaModel.Id = usuarioLogado.Id;

                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    
                    TempData["MensagemSucesso"] = $"Senha alterada com sucesso.";

                    return View("Index", alterarSenhaModel);
                }

                return View("Index",alterarSenhaModel);
            }
            catch(Exception e)
            {
                TempData["MensagemErro"] = $"Ops, erro ao alterar senha, detalhe do erro: {e.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
