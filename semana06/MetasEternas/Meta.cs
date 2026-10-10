
using System;
using System.Text;

abstract class Meta
{
    private string _nome;
    private string _descricao;
    private int _pontos;

    public string Nome
    {
        get { return _nome; }
    }

    public string Descricao
    {
        get { return _descricao; }
    }

    public int Pontos
    {
        get { return _pontos; }
    }

    protected Meta(string nome, string descricao, int pontos)
    {
        _nome = nome;
        _descricao = descricao;
        _pontos = pontos;
    }

    public abstract int Registrar();

    public abstract string ObterTipo();

    public abstract string ObterDados();

    public virtual bool EstaConcluida()
    {
        return false;
    }

    public virtual string ObterStatus()
    {
        return "[ ]";
    }

    public virtual string ObterDescricaoProgresso()
    {
        return "";
    }

    protected static string Codificar(string texto)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(texto));
    }

    protected static string Decodificar(string texto)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(texto));
    }

    public static Meta? CriarAPartirDoArquivo(string linha)
    {
        string[] partes = linha.Split('|');

        try
        {
            switch (partes[0])
            {
                case "S":
                    return new MetaSimples(
                        Decodificar(partes[1]),
                        Decodificar(partes[2]),
                        int.Parse(partes[3]),
                        bool.Parse(partes[4])
                    );

                case "E":
                    return new MetaEterna(
                        Decodificar(partes[1]),
                        Decodificar(partes[2]),
                        int.Parse(partes[3])
                    );

                case "C":
                    return new MetaChecklist(
                        Decodificar(partes[1]),
                        Decodificar(partes[2]),
                        int.Parse(partes[3]),
                        int.Parse(partes[4]),
                        int.Parse(partes[5]),
                        int.Parse(partes[6])
                    );

                default:
                    return null;
            }
        }
        catch (FormatException)
        {
            return null;
        }
        catch (ArgumentException)
        {
            return null;
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    }
}
