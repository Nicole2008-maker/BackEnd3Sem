using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    Usuario BuscarPorId(Guid IdUsuario);
    Usuario BuscarPorEmailESenha(string Email, string Senha); 
}
