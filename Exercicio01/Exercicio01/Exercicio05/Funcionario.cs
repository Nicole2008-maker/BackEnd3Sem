using System;

namespace Exercicio01.Exercicio05;
public class Funcionario : Pessoa
{
    public double Salario { get; set; }

    public Funcionario(string nome, int idade, double salario)
        : base(nome, idade)
    {
        Salario = salario;
    }

    public void ExibirDados()
    {
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Idade: " + Idade);
        Console.WriteLine("Salário: R$ " + Salario);
    }
}
