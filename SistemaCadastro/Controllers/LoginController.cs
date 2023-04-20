using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Helper;
using SistemaCadastro.Models;
using SistemaCadastro.Repositorio;

namespace SistemaCadastro.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //se usuario estiver logado rediresionar para  a home
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult RedefinirSenha()
        {
            
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorlogin(loginModel.Login);


                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"senha inválida. Por favor, Tente novamente.";
                    }
                    TempData["MensagemErro"] = $"Usúario e/ou senha inválido(s). Por favor, Tente novamente.";
                    return RedirectToAction("Index");
                }
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Ops, erro ao validar Login, detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLoginEmail(redefinirSenhaModel.Login, redefinirSenhaModel.Email);


                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        
                        TempData["MensagemSucesso"] = $"Enviamos para seu e-mail uma nova senha.";
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["MensagemErro"] = $"Login e/ou E-mail inválido(s). Por favor, Tente novamente.";
                    
                }
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Ops, erro ao Redefinir Senha, detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
