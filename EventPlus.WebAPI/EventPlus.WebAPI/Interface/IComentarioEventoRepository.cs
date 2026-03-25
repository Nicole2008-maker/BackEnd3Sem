using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface IComentarioEventoRepository
{
    void Cadastrar(ComentarioEvento comentarioEvento);
    void Deletar(Guid IdComentarioEvento);
    List<ComentarioEvento> Listar();
    ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento);
    List<ComentarioEvento>ListarSomenteExibe(Guid IdEvento);
    object? BuscarPorIdUsuario(Guid idUsuario);
}
