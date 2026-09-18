public class Fracao
{
    private int _numerador;
    private int _denominador;

    public Fracao()
    {
        _numerador = 1;
        _denominador = 1;
    }

    public Fracao(int numerador)
    {
        _numerador = numerador;
        _denominador = 1;
    }

    public Fracao(int numerador, int denominador)
    {
        _numerador = numerador;
        _denominador = denominador;
    }

    public int GetNumerador()
    {
        return _numerador;
    }

    public void SetNumerador(int numerador)
    {
        _numerador = numerador;
    }

    public int GetDenominador()
    {
        return _denominador;
    }

    public void SetDenominador(int denominador)
    {
        _denominador = denominador;
    }

    public string ObterFracaoEmTexto()
    {
        return $"{_numerador}/{_denominador}";
    }

    public double ObterFracaoEmDecimal()
    {
        return (double)_numerador / _denominador;
    }
}