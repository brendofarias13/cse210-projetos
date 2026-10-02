using System.Collections.Generic;

public class AtividadeDeListagem : Atividade
{
    private int _contador;
    private List<string> _perguntas;

    public AtividadeDeListagem()
    {
        _nome = "Listagem";
        _descricao = "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida.";
        _duracao = 30;

        _contador = 0;
        _perguntas = new List<string>();
    }

    public void Executar()
    {
    }

    public string ObterPerguntaAleatoria()
    {
        return "";
    }

    public List<string> ObterListaDoUsuario()
    {
        return new List<string>();
    }
}