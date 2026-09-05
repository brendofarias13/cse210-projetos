using System;

class Program
{
    static void Main(string[] args)
    {
        ExibirBoasVindas();

        string nome = PerguntarNomeUsuario();

        int numeroFavorito = PerguntarNumeroFavorito();

        int numeroQuadrado = ElevarAoQuadrado(numeroFavorito);

        ExibirResultado(nome, numeroQuadrado);
    }

    static void ExibirBoasVindas()
    {
        Console.WriteLine("Bem-vindo ao programa!");
    }

    static string PerguntarNomeUsuario()
    {
        Console.Write("Por favor, insira seu nome: ");
        string nome = Console.ReadLine();

        return nome;
    }

    static int PerguntarNumeroFavorito()
    {
        Console.Write("Por favor, insira seu número favorito: ");
        string entrada = Console.ReadLine();
        int numero = int.Parse(entrada);

        return numero;
    }

    static int ElevarAoQuadrado(int numero)
    {
        int resultado = numero * numero;

        return resultado;
    }

    static void ExibirResultado(string nome, int numeroQuadrado)
    {
        Console.WriteLine($"{nome}, o quadrado do seu número é {numeroQuadrado}");
    }
}