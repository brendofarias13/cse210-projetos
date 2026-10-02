using System;
using System.Collections.Generic;

public class AtividadeDeListagem : Atividade
{
    private int _contador;
    private List<string> _perguntas;

    public AtividadeDeListagem()
    {
        _nome = "Listagem";
        _descricao = "Esta atividade ajudará você a refletir sobre as coisas " +
                     "boas da sua vida. Pense em uma pergunta e tente listar " +
                     "o maior número possível de respostas.";

        _contador = 0;

        _perguntas = new List<string>
        {
            "Quem são pessoas que você admira?",
            "Quais são suas comidas favoritas?",
            "Quais são coisas que você gosta de fazer?",
            "Quais são lugares que você gostaria de visitar?",
            "Quais são coisas pelas quais você é grato?",
            "Quais são suas qualidades?",
            "Quais são coisas que fazem você feliz?",
            "Quais são coisas que você aprendeu recentemente?"
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("Pense sobre a seguinte pergunta:");
        Console.WriteLine();

        string pergunta = ObterPerguntaAleatoria();

        Console.WriteLine($"--- {pergunta} ---");
        Console.WriteLine();

        Console.WriteLine("Comece em:");
        ExibirContagemRegressiva(5);
        Console.WriteLine();
        Console.WriteLine();

        List<string> respostas = ObterListaDoUsuario();

        Console.WriteLine();
        Console.WriteLine($"Você listou {respostas.Count} itens.");

        ExibirMensagemFinal();
    }

    private string ObterPerguntaAleatoria()
    {
        Random random = new Random();
        int indice = random.Next(_perguntas.Count);

        string pergunta = _perguntas[indice];

        // Remove a pergunta usada para evitar repetição.
        _perguntas.RemoveAt(indice);

        return pergunta;
    }

    private List<string> ObterListaDoUsuario()
    {
        List<string> respostas = new List<string>();

        DateTime fim = DateTime.Now.AddSeconds(_duracao);

        while (DateTime.Now < fim)
        {
            Console.Write("> ");
            string resposta = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(resposta))
            {
                respostas.Add(resposta);
                _contador++;
            }
        }

        return respostas;
    }
}