using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLoginEmail(string login, string email);

        UsuarioModel BuscarPorlogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();

        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
    }
}
