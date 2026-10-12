using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Atividade> atividades = new List<Atividade>();

        atividades.Add(new Corrida(new DateTime(2026, 10, 10), 30, 5.0));
        atividades.Add(new Ciclismo(new DateTime(2026, 10, 10), 45, 20.0));
        atividades.Add(new Natacao(new DateTime(2026, 10, 10), 30, 20));

        foreach (Atividade atividade in atividades)
        {
            Console.WriteLine(atividade.ObterResumo());
        }
    }
}
