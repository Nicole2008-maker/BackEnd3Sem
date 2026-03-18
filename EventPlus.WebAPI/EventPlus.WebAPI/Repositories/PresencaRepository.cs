using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class PresencaRepository : IPresencaRepository
{

    private readonly EventContext _context;
    public PresencaRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Metodo que alterna a situacao da presenca
    /// </summary>
    /// <param name="id">Id da presenca a ser alterada</param>
    public void Atualizar(Guid id)
    {
        var presencaBuscada = _context.Presencas.Find(id);

        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo que busca uma presenca por id
    /// </summary>
    /// <param name="id">id da presenca a ser buscadaa</param>
    /// <returns>presenca buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _context.Presencas.Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituicaoNavigation)
            .FirstOrDefault(p => p.IdPresenca == id)!;
    }

    public void Deletar(Guid id)
    {
        
    }

    public void Inscrever(Presenca presenca)
    {
        throw new NotImplementedException();
    }

    public List<Presenca> Listar()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Metodo que lista as presencas de um usuario especifico
    /// </summary>
    /// <param name="IdUsuario">id do usuario para filtragem</param>
    /// <returns>lista de presencas de um usuario</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas.Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituicaoNavigation)
            .Where(p => p.IdUsuario == IdUsuario)
            .ToList();
    }
}
