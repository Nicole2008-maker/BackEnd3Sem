using FilmesMoura1.WebAPI.Models;

namespace FilmesMoura1.WebAPI.Interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario novoUsuario);
    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorEmailSenha(string email, string senha);
}
