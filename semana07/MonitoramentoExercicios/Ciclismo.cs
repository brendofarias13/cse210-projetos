
public class Ciclismo : Atividade
{
    private double _velocidade;

    public Ciclismo(DateTime data, int duracao, double velocidade)
        : base(data, duracao)
    {
        _velocidade = velocidade;
    }

    public override double ObterDistancia()
    {
        return (_velocidade * ObterDuracao()) / 60;
    }

    public override double ObterVelocidade()
    {
        return _velocidade;
    }

    public override double ObterRitmo()
    {
        return ObterDuracao() / ObterDistancia();
    }
}
