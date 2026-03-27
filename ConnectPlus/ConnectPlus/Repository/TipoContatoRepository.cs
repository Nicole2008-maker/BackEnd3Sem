
using ConnectPlus.BdContextConnect;
using ConnectPlus.Interface;
using ConnectPlus.Models;
namespace ConnectPlus_Moura.Repository;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly ConnecContext _context;

    public TipoContatoRepository(ConnecContext context)
    {
        _context = context;
    }


    public void Cadastrar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }


    public void Atualizar(Guid id, TipoContato tipoContato)
    {
        var tipoContatoExistente = _context.TipoContatos.Find(id);

        if (tipoContatoExistente != null)
        {
            tipoContatoExistente.Titulo = tipoContato.Titulo;

            _context.SaveChanges();
        }


    }




    public TipoContato BuscarPorId(Guid id)
    {
        return _context.TipoContatos.Find(id)!;
    }



    public void Deletar(Guid id)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(id);

        if (tipoContatoBuscado != null)
        {
            _context.TipoContatos.Remove(tipoContatoBuscado);
            _context.SaveChanges();
        }
    }


    public List<TipoContato> Listar()
    {
        return _context.TipoContatos.OrderBy(TipoContatos => TipoContatos.Titulo).ToList();
    }
}

