
using ConnectPlus.Models;

namespace ConnectPlus.Interface;

public interface ITipoContatoRepository
{
    void Cadastrar(TipoContato tipoContato);
    TipoContato BuscarPorId(Guid Id);
    List<TipoContato> Listar();
    void Deletar(Guid Id);
    void Atualizar(Guid Id, TipoContato tipoContato);
}
