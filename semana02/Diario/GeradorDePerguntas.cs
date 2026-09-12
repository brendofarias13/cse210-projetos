using System;
using System.Collections.Generic;

public class GeradorDePerguntas
{
    private List<string> _perguntas = new List<string>();

    public GeradorDePerguntas()
    {
        _perguntas.Add("Quem foi a pessoa mais interessante com quem interagi hoje?");
        _perguntas.Add("Qual foi a melhor parte do meu dia?");
        _perguntas.Add("Como vi a mão do Senhor em minha vida hoje?");
        _perguntas.Add("Qual foi a emoção mais forte que senti hoje?");
        _perguntas.Add("O que aprendi hoje?");
    }

    public string ObterPerguntaAleatoria()
    {
        Random random = new Random();
        int indice = random.Next(_perguntas.Count);

        return _perguntas[indice];
    }
}