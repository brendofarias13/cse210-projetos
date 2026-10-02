using System;
using System.Collections.Generic;

public class AtividadeDeReflexao : Atividade
{
    private List<string> _perguntas;
    private List<string> _reflexoes;

    public AtividadeDeReflexao()
    {
        _nome = "Reflexão";
        _descricao = "Esta atividade ajudará você a refletir sobre momentos " +
                     "da sua vida em que demonstrou força e resiliência.";

        _perguntas = new List<string>
        {
            "Por que essa experiência foi significativa para você?",
            "O que você aprendeu com essa experiência?",
            "Como você se sentiu quando isso aconteceu?",
            "O que você aprendeu sobre si mesmo?",
            "Como essa experiência ajudou você a crescer?",
            "Como você pode usar o que aprendeu no futuro?",
            "Que outras pessoas estavam envolvidas nessa experiência?",
            "O que tornou essa experiência difícil?",
            "O que tornou essa experiência positiva?"
        };

        _reflexoes = new List<string>
        {
            "Pense em uma época em que você precisou superar algo difícil.",
            "Pense em uma ocasião em que você ajudou alguém.",
            "Pense em uma época em que alguém ajudou você.",
            "Pense em uma experiência que fez você se sentir grato.",
            "Pense em uma época em que você aprendeu algo importante.",
            "Pense em uma situação em que você precisou ser corajoso."
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("Comece pensando sobre a seguinte situação:");
        Console.WriteLine();

        string reflexao = ObterReflexaoAleatoria();

        Console.WriteLine($"--- {reflexao} ---");
        Console.WriteLine();

        ExibirProgresso(5);
        Console.WriteLine();
        Console.WriteLine();

        DateTime fim = DateTime.Now.AddSeconds(_duracao);

        while (DateTime.Now < fim && _perguntas.Count > 0)
        {
            string pergunta = ObterPerguntaAleatoria();

            Console.WriteLine(pergunta);
            Console.WriteLine();

            int segundosRestantes =
                (int)(fim - DateTime.Now).TotalSeconds;

            if (segundosRestantes > 0)
            {
                ExibirProgresso(Math.Min(5, segundosRestantes));
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        ExibirMensagemFinal();
    }

    private string ObterReflexaoAleatoria()
    {
        Random random = new Random();
        int indice = random.Next(_reflexoes.Count);

        string reflexao = _reflexoes[indice];

        // Remove a reflexão usada para evitar repetição.
        _reflexoes.RemoveAt(indice);

        return reflexao;
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
}