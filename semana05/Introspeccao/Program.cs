using System;

class Program
{
    static void Main(string[] args)
    {
        // Criatividade:
        // As perguntas e reflexões usadas são removidas das listas,
        // evitando que sejam repetidas até que todas sejam utilizadas.

        int opcao = 0;

        while (opcao != 4)
        {
            Console.Clear();

            Console.WriteLine("=== PROGRAMA DE INTROSPECÇÃO ===");
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine();
            Console.WriteLine("1. Atividade de Respiração");
            Console.WriteLine("2. Atividade de Reflexão");
            Console.WriteLine("3. Atividade de Listagem");
            Console.WriteLine("4. Sair");
            Console.WriteLine();

            Console.Write("Escolha uma opção: ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out opcao))
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida.");
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                continue;
            }

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    AtividadeDeRespiracao respiracao =
                        new AtividadeDeRespiracao();

                    respiracao.Executar();
                    break;

                case 2:
                    AtividadeDeReflexao reflexao =
                        new AtividadeDeReflexao();

                    reflexao.Executar();
                    break;

                case 3:
                    AtividadeDeListagem listagem =
                        new AtividadeDeListagem();

                    listagem.Executar();
                    break;

                case 4:
                    Console.WriteLine("Até logo!");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            if (opcao != 4)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione Enter para voltar ao menu...");
                Console.ReadLine();
            }
        }
    }
}