
class MetaSimples : Meta
{
    private bool _concluida;

    public MetaSimples(
        string nome,
        string descricao,
        int pontos,
        bool concluida = false
    ) : base(nome, descricao, pontos)
    {
        _concluida = concluida;
    }

    public override int Registrar()
    {
        if (_concluida)
        {
            System.Console.WriteLine("Essa meta já foi concluída.");
            return 0;
        }

        _concluida = true;
        System.Console.WriteLine($"Meta concluída! Você ganhou {Pontos} pontos.");
        return Pontos;
    }

    public override string ObterTipo()
    {
        return "Simples";
    }

    public override bool EstaConcluida()
    {
        return _concluida;
    }

    public override string ObterStatus()
    {
        return _concluida ? "[X]" : "[ ]";
    }

    public override string ObterDados()
    {
        return $"S|{Codificar(Nome)}|{Codificar(Descricao)}|{Pontos}|{_concluida}";
    }
}
