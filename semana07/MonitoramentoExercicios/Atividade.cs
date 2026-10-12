
using System;
using System.Globalization;

public abstract class Atividade
{
    private DateTime _data;
    private int _duracao;

    public Atividade(DateTime data, int duracao)
    {
        _data = data;
        _duracao = duracao;
    }

    public DateTime ObterData()
    {
        return _data;
    }

    public int ObterDuracao()
    {
        return _duracao;
    }

    public abstract double ObterDistancia();
    public abstract double ObterVelocidade();
    public abstract double ObterRitmo();

    public virtual string ObterResumo()
    {
        string data = _data.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

        return $"{data} {GetType().Name} ({_duracao} min) - " +
               $"Distância {ObterDistancia():F2} km, " +
               $"Velocidade {ObterVelocidade():F2} km/h, " +
               $"Ritmo: {ObterRitmo():F2} min por km";
    }
}

