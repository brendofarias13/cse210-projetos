public class TarefaDeMatematica : Tarefa
{
    private string _secao;
    private string _problemas;

    public TarefaDeMatematica(
        string nomeEstudante,
        string topico,
        string secao,
        string problemas) : base(nomeEstudante, topico)
    {
        _secao = secao;
        _problemas = problemas;
    }

    public string ObterListaDeTarefas()
    {
        return $"Capítulo {_secao} Problemas {_problemas}";
    }
}