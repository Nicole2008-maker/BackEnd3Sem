

namespace Exercicio01.Exercicio08;
public class Administrador : IAutenticavel
{
    public string Nome { get; set; }
    private string Senha { get; set; }

    public Administrador(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }

    public bool Autenticar(string senha)
    {
       
        if (!senha.StartsWith("ADM"))
            return false;

        return Senha == senha;
    }
}

