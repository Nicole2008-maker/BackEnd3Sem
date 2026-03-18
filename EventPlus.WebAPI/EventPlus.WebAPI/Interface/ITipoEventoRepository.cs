using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface ITipoEventoRepository
{
    void Cadastrar(TipoEvento tipoEvento);
    void Deletar(Guid id);
    List<TipoEvento> Listar();
    TipoEvento BuscarPorId(Guid id);
    void Atualizar(Guid id, TipoEvento tipoEvento);

}
