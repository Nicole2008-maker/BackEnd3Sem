

using ConnectPlus.BdContextConnect;
using ConnectPlus.Interface;
using ConnectPlus.Models;
namespace ConnectPlus_Moura.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnecContext _context;
    public ContatoRepository(ConnecContext context)
    {
        _context = context;
    }



    public void Atualizar(Guid id, Contato contato)
    {
        var contatoExistente = _context.Contatos.Find(id);
        if (contatoExistente == null)
        {
            contatoExistente.Nome = contato.Nome;
            contatoExistente.FormaDeContato = contato.FormaDeContato;
            contatoExistente.Imagem = contato.Imagem;
            _context.SaveChanges();
        }

    }


    public Contato BuscarPorId(Guid id)
    {
        return _context.Contatos.Find(id)!;
    }


    public void Cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }


    public void Deletar(Guid id)
    {
        var contatoBuscado = _context.Contatos.Find(id);

        if (contatoBuscado != null)
        {
            _context.Contatos.Remove(contatoBuscado);
            _context.SaveChanges();
        }
    }


    public List<Contato> Listar()
    {
        return _context.Contatos.OrderBy(Contados => Contados.Nome).ToList();
    }
}
