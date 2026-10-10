
using System;

class Program
{
    static void Main(string[] args)
    {
        GerenciadorDeMetas gerenciador = new GerenciadorDeMetas();

        gerenciador.Carregar();

        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=== PROGRAMA DE METAS ETERNAS ===");
            Console.WriteLine($"Pontuação: {gerenciador.Pontuacao}");
            Console.WriteLine($"Nível: {gerenciador.ObterNivel()}");
            Console.WriteLine($"Título: {gerenciador.ObterTitulo()}");
            Console.WriteLine();
            Console.WriteLine("1. Mostrar metas");
            Console.WriteLine("2. Criar nova meta");
            Console.WriteLine("3. Registrar progresso");
            Console.WriteLine("4. Salvar metas");
            Console.WriteLine("5. Carregar metas");
            Console.WriteLine("6. Salvar e sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    gerenciador.MostrarMetas();
                    Pausar();
                    break;

                case "2":
                    gerenciador.CriarMeta();
                    Pausar();
                    break;

                case "3":
                    gerenciador.RegistrarProgresso();
                    Pausar();
                    break;

                case "4":
                    gerenciador.Salvar();
                    Pausar();
                    break;

                case "5":
                    gerenciador.Carregar();
                    Pausar();
                    break;

                case "6":
                    gerenciador.Salvar();
                    continuar = false;
                    Console.WriteLine("Metas salvas. Até a próxima!");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    Pausar();
                    break;
            }
        }
    }

    private static void Pausar()
    {
        Console.WriteLine();
        Console.Write("Pressione Enter para continuar...");
        Console.ReadLine();
    }

    /*
     * Recursos extras para demonstrar criatividade:
     * - Sistema de níveis baseado na pontuação acumulada.
     * - Títulos especiais conforme o nível alcançado.
     * - Bônus de pontos ao completar metas de checklist.
     * - Salvamento e carregamento das metas e da pontuação.
     */
}
