
namespace Exercicio01.Exercicio04;

public class Pessoa
{
    private int _idade;

    public string Nome { get; set; }

    public int Idade
    {
        get { return _idade; }
        set
        {
            if (value > 0)
                _idade = value;
            else
                throw new ArgumentException("A idade deve ser maior que zero.");
        }
    }


    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade; 
    }
}
