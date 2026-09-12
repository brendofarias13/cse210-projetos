using System;

class Program
{
    static void Main(string[] args)
    {
        Diario diario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();

        int opcao = 0;

        // Esta é a parte principal do programa.
        // O usuário escolhe o que deseja fazer no diário.
        while (opcao != 6)
        {
            Console.WriteLine();
            Console.WriteLine("===== DIÁRIO =====");
            Console.WriteLine("1. Escrever novo registro");
            Console.WriteLine("2. Exibir diário");
            Console.WriteLine("3. Salvar diário");
            Console.WriteLine("4. Carregar diário");
            Console.WriteLine("5. Ver quantidade de registros");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                // Uma pergunta é escolhida aleatoriamente para o usuário responder.
                string pergunta = gerador.ObterPerguntaAleatoria();

                Console.WriteLine();
                Console.WriteLine($"Pergunta: {pergunta}");

                Console.Write("Sua resposta: ");
                string resposta = Console.ReadLine();

                // A data é registrada automaticamente no momento da entrada.
                string data = DateTime.Now.ToShortDateString();

                Registro registro = new Registro(
                    data,
                    pergunta,
                    resposta
                );

                diario.AdicionarRegistro(registro);

                Console.WriteLine();
                Console.WriteLine("Registro adicionado com sucesso!");
            }
            else if (opcao == 2)
            {
                // Exibe todos os registros que estão armazenados no diário.
                Console.WriteLine();
                Console.WriteLine("===== MEU DIÁRIO =====");

                diario.ExibirTodos();
            }
            else if (opcao == 3)
            {
                // Salva os registros do diário em um arquivo.
                Console.Write("Digite o nome do arquivo: ");

                string arquivo = Console.ReadLine();

                diario.SalvarNoArquivo(arquivo);

                Console.WriteLine("Diário salvo com sucesso!");
            }
            else if (opcao == 4)
            {
                // Carrega os registros de um arquivo para o diário.
                Console.Write("Digite o nome do arquivo: ");

                string arquivo = Console.ReadLine();

                diario.CarregarDoArquivo(arquivo);

                Console.WriteLine("Diário carregado com sucesso!");
            }
            else if (opcao == 5)
            {
                // Funcionalidade extra do projeto:
                // mostra ao usuário quantos registros existem no diário.
                int quantidade = diario.ObterQuantidadeRegistros();

                Console.WriteLine();
                Console.WriteLine(
                    $"Você possui {quantidade} registro(s) no diário."
                );
            }
            else if (opcao == 6)
            {
                Console.WriteLine("Até logo!");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}