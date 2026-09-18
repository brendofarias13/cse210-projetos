using System;

class Program
{
    static void Main(string[] args)
    {
        Referencia referencia = new Referencia("João", 3, 16);

        Escritura escritura = new Escritura(
            referencia,
            "Porque Deus amou o mundo de tal maneira que deu o seu Filho unigênito para que todo aquele que nele crê não pereça mas tenha a vida eterna."
        );

        // Funcionalidade extra:
        // O usuário pode escolher quantas palavras serão escondidas
        // a cada rodada de prática da memorização.
        Console.WriteLine("PROGRAMA DE MEMORIZAÇÃO DE ESCRITURAS");
        Console.WriteLine();
        Console.WriteLine("Escolha quantas palavras deseja esconder por rodada.");
        Console.WriteLine("Digite um número entre 1 e 5.");
        Console.WriteLine();

        int quantidade = 3;

        while (true)
        {
            Console.Write("Quantidade: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out quantidade) &&
                quantidade >= 1 &&
                quantidade <= 5)
            {
                break;
            }

            Console.WriteLine("Digite um número válido entre 1 e 5.");
        }

        while (!escritura.TodasPalavrasEscondidas())
        {
            Console.Clear();

            Console.WriteLine(escritura.ObterTexto());
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para esconder palavras.");
            Console.WriteLine("Digite 'sair' para encerrar o programa.");
            Console.WriteLine();

            string entrada = Console.ReadLine();

            if (entrada.ToLower() == "sair")
            {
                Console.WriteLine();
                Console.WriteLine("Programa encerrado.");
                return;
            }

            escritura.EsconderPalavras(quantidade);
        }

        Console.Clear();

        Console.WriteLine(escritura.ObterTexto());
        Console.WriteLine();
        Console.WriteLine("Parabéns! Você memorizou a escritura!");
    }
}