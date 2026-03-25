using ConnectPlus.Models;

namespace ConnectPlus.Interface;

public interface IContatoRepository
{
    void Cadastrar(Contato contato);
    Contato BuscarPorId(Guid Id);
    List<Contato> Listar();
    void Deletar(Guid Id);
    void Atualizar(Guid Id, Contato contato);
}