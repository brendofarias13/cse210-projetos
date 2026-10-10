
class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
    }

    public override int Registrar()
    {
        System.Console.WriteLine($"Você ganhou {Pontos} pontos!");
        return Pontos;
    }

    public override string ObterTipo()
    {
        return "Eterna";
    }

    public override string ObterStatus()
    {
        return "[∞]";
    }

    public override string ObterDados()
    {
        return $"E|{Codificar(Nome)}|{Codificar(Descricao)}|{Pontos}";
    }
}
