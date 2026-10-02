using System;
using System.Threading;

public class Atividade
{
    protected string _nome;
    protected string _descricao;
    protected int _duracao;

    public Atividade()
    {
        _nome = "";
        _descricao = "";
        _duracao = 0;
    }

    public void ExibirMensagemInicial()
    {
        Console.Clear();

        Console.WriteLine($"--- {_nome} ---");
        Console.WriteLine();
        Console.WriteLine(_descricao);
        Console.WriteLine();

        Console.Write("Por quanto tempo, em segundos, você gostaria de fazer esta atividade? ");
        _duracao = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Prepare-se...");
        ExibirProgresso(3);
        Console.WriteLine();
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine();
        Console.WriteLine("Muito bem!");
        Console.WriteLine();
        Console.WriteLine($"Você concluiu a atividade de {_nome} por {_duracao} segundos.");
        Console.WriteLine();
        Console.WriteLine("Bom trabalho!");
        ExibirProgresso(3);
        Console.WriteLine();
    }

    public void ExibirProgresso(int segundos)
    {
        string[] simbolos = { "|", "/", "-", "\\" };

        for (int i = 0; i < segundos * 2; i++)
        {
            Console.Write($"\b{simbolos[i % simbolos.Length]}");
            Thread.Sleep(500);
        }

        Console.Write("\b ");
    }

    public void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}