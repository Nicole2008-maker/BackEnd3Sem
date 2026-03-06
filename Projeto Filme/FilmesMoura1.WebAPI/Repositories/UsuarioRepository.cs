using FilmesMoura1.WebAPI.BdContextFilme;
using FilmesMoura1.WebAPI.Interfaces;
using FilmesMoura1.WebAPI.Models;
using FilmesMoura1.WebAPI.Utils;

namespace FilmesMoura1.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly FilmeContext _context;
    public UsuarioRepository(FilmeContext context)
    {
        _context = context;
    }

    public Usuario BuscarPorEmailSenha(string email, string senha)
    {
        try
        {
            Usuario usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == email)!;
            if (usuarioBuscado != null)
            {
                bool confere = Criptografia.ComparaHash(senha, usuarioBuscado.Senha);

                if (confere)
                {
                    return usuarioBuscado;
                }
            }

            return null!;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public Usuario BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(Usuario novoUsuario)
    {
        try
        {
            novoUsuario.IdUsuario = Guid.NewGuid().ToString();
            novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

             
        }
        catch (Exception)
        {

            throw;
        }
    }
}
