using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class TipoEventoRepository : ITipoEventoRepository
{

    private readonly EventContext _context;
    public TipoEventoRepository (EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tipoEvento"></param>
    /// 


    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var TipoEventoBuscado = _context.TipoEventos.Find(id);
        if (TipoEventoBuscado != null)
        {
            TipoEventoBuscado.Titulo = tipoEvento.Titulo;

            _context.SaveChanges();
        }
    }

    public TipoEvento BuscarPorId(Guid id)
    {
        return _context.TipoEventos.Find(id)!;
    }

    public void Cadastrar(TipoEvento tipoEvento)
    {
       _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);
        if (tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }

    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(tipoEvento => tipoEvento.Titulo).ToList();
    }
}
