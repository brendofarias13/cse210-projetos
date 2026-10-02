using System;

class Program
{
    static void Main(string[] args)
    {
        // Testando a classe Tarefa
        Tarefa tarefa = new Tarefa("Samuel Silva", "Multiplicação");
        Console.WriteLine(tarefa.ObterResumo());

        Console.WriteLine();

        // Testando a classe TarefaDeMatematica
        TarefaDeMatematica matematica = new TarefaDeMatematica(
            "Roberto Rodriguez",
            "Frações",
            "7.3",
            "8-19"
        );

        Console.WriteLine(matematica.ObterResumo());
        Console.WriteLine(matematica.ObterListaDeTarefas());

        Console.WriteLine();

        // Testando a classe TarefaDeRedacao
        TarefaDeRedacao redacao = new TarefaDeRedacao(
            "Maria Antunes",
            "História da Europa",
            "As Causas da Segunda Guerra Mundial"
        );

        Console.WriteLine(redacao.ObterResumo());
        Console.WriteLine(redacao.ObterInformacoesDaRedacao());
    }
}