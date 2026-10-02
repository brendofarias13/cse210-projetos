using System.Collections.Generic;

public class AtividadeDeReflexao : Atividade
{
    private List<string> _reflexoes;
    private List<string> _perguntas;

    public AtividadeDeReflexao()
    {
        _nome = "Reflexão";
        _descricao = "Esta atividade ajudará você a refletir sobre momentos da sua vida.";
        _duracao = 30;

        _reflexoes = new List<string>();
        _perguntas = new List<string>();
    }

    public void Executar()
    {
    }

    public string ObterReflexoesAleatorias()
    {
        return "";
    }

    public string ObterPerguntasAleatorias()
    {
        return "";
    }

    public void ExibirReflexoes()
    {
    }

    public void ExibirPerguntas()
    {
    }
}