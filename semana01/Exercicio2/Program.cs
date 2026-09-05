using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite sua nota: ");
        string entrada = Console.ReadLine();
        int nota = int.Parse(entrada);

        string letra;

        if (nota >= 90)
        {
            letra = "A";
        }
        else if (nota >=80)
        {
            letra = "B";
        }
        else if (nota >= 70)
        {
            letra = "C";
        }
        else if (nota >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        Console.WriteLine($"Sua nota conceitual é: {letra}");

        if (nota >= 70)
        {
            Console.WriteLine("Parabéns! Você foi aprovado no curso.");
        }
        else
        {
            Console.WriteLine("Continue se esforçando. Na próxima vez você conseguirá!");
        }
    }
}