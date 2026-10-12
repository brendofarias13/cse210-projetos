
public class Natacao : Atividade
{
    private int _voltas;

    public Natacao(DateTime data, int duracao, int voltas)
        : base(data, duracao)
    {
        _voltas = voltas;
    }

    public override double ObterDistancia()
    {
        return (_voltas * 50.0) / 1000;
    }

    public override double ObterVelocidade()
    {
        return (ObterDistancia() / ObterDuracao()) * 60;
    }

    public override double ObterRitmo()
    {
        return ObterDuracao() / ObterDistancia();
    }
}
