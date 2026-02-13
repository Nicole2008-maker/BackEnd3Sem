
namespace Exercicio01.Exercicio06;
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


    public void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {Nome}.");
    }

   
    public void Apresentar(string sobrenome)
    {
        Console.WriteLine($"Olá, meu nome é {Nome} {sobrenome}.");
    }
}
