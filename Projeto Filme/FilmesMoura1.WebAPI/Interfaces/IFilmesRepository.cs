using FilmesMoura1.WebAPI.Models;

namespace FilmesMoura1.WebAPI.Interfaces;

public interface IFilmesRepository
{
    Filme BuscarPorId(Guid Id);
    List<Filme> Listar();
    void Cadastrar(Filme novoFilme);
    void Deletar(Guid id);
    void AtualizarIdCorpo(Filme filmeAtualizado);
    void AtualizarIdUrl(Guid Id, Filme filmeAtualizado);
}
