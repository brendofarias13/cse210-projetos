using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();

        Console.WriteLine("Insira uma lista de números e digite 0 quando terminar.");

        int numero;

        do
        {
            Console.Write("Insira o número: ");
            string entrada = Console.ReadLine();
            numero = int.Parse(entrada);

            if (numero != 0)
            {
                numeros.Add(numero);
            }

        } while (numero != 0);

        int soma = 0;

        foreach (int n in numeros)
        {
            soma += n;
        }

        double media = (double)soma / numeros.Count;

        int maior = numeros[0];

        foreach (int n in numeros)
        {
            if (n > maior)
            {
                maior = n;
            }
        }

        Console.WriteLine($"A soma é: {soma}");
        Console.WriteLine($"A média é: {media}");
        Console.WriteLine($"O maior número é: {maior}");
    }
}