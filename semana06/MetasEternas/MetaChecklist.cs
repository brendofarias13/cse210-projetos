
class MetaChecklist : Meta
{
    private int _quantidadeDesejada;
    private int _bonus;
    private int _quantidadeConcluida;

    public MetaChecklist(
        string nome,
        string descricao,
        int pontos,
        int quantidadeDesejada,
        int bonus,
        int quantidadeConcluida = 0
    ) : base(nome, descricao, pontos)
    {
        _quantidadeDesejada = quantidadeDesejada;
        _bonus = bonus;
        _quantidadeConcluida = quantidadeConcluida;
    }

    public override int Registrar()
    {
        if (EstaConcluida())
        {
            System.Console.WriteLine("Essa meta de checklist já foi concluída.");
            return 0;
        }

        _quantidadeConcluida++;

        int pontosGanhos = Pontos;

        System.Console.WriteLine(
            $"Progresso: {_quantidadeConcluida}/{_quantidadeDesejada}"
        );

        if (EstaConcluida())
        {
            pontosGanhos += _bonus;
            System.Console.WriteLine(
                $"Meta concluída! Bônus de {_bonus} pontos!"
            );
        }

        System.Console.WriteLine($"Você ganhou {pontosGanhos} pontos.");
        return pontosGanhos;
    }

    public override string ObterTipo()
    {
        return "Checklist";
    }

    public override bool EstaConcluida()
    {
        return _quantidadeConcluida >= _quantidadeDesejada;
    }

    public override string ObterStatus()
    {
        return EstaConcluida() ? "[X]" : "[ ]";
    }

    public override string ObterDescricaoProgresso()
    {
        return $"Concluídas: {_quantidadeConcluida}/{_quantidadeDesejada} | Bônus: {_bonus}";
    }

    public override string ObterDados()
    {
        return $"C|{Codificar(Nome)}|{Codificar(Descricao)}|{Pontos}|{_quantidadeDesejada}|{_bonus}|{_quantidadeConcluida}";
    }
}
