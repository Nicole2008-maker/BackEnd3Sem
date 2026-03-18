using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;
    public UsuarioRepository(EventContext context)
    {
     _context = context;
    }
    /// <summary>
    /// Busca o usuario pelo e-mail e valida o hash da senha
    /// </summary>
    /// <param name="Email">e-mail do usuario</param>
    /// <param name="Senha">senha do usuario</param>
    /// <returns>Usuario buscado e validado</returns>

    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
       var usuarioBuscado = _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(
           usuario => usuario.Email == Email);

        if (usuarioBuscado != null)
        {
           bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

            if(confere)
            {
                return usuarioBuscado; 
            }
        }
        return null;
    }
    
    public Usuario BuscarPorId(Guid IdUsuario)
    {
        return _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.
    IdUsuario == IdUsuario)!;
    }
    /// <summary>
    /// Cadastra um novo usuario com a senha criptografada
    /// </summary>
    /// <param name="IdUsuario">Usuario a se cadastrado</param>

    public void Cadastrar(Usuario usuario)
    {
      usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

    }
}
