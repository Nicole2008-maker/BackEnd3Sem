
namespace Exercicio01.Exercicios03;

public class Pessoa
{
    private int _idade;

    public int Idade
    {
        get { return _idade; }
        set
        {
            if (value > 0)
            {
                _idade = value;
            }
            else
            {
                throw new ArgumentException("A idade deve ser maior que zero.");
            }
        }
    }
}
