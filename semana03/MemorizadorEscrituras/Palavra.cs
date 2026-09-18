public class Palavra
{
    private string _texto;
    private bool _escondida;

    public Palavra(string texto)
    {
        _texto = texto;
        _escondida = false;
    }

    public void Esconder()
    {
        _escondida = true;
    }

    public bool EstaEscondida()
    {
        return _escondida;
    }

    public string ObterTexto()
    {
        if (_escondida)
        {
            return new string('_', _texto.Length);
        }

        return _texto;
    }
}