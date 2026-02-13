
namespace Exercicio01.Exercicio08;

public class Usuario : IAutenticavel
{
    public string Nome { get; set; }
    private string Senha { get; set; }

    public Usuario(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return Senha == senha;
    }
}

