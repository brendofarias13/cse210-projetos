public class Produto
{
    private string _nome;
    private string _id;
    private double _preco;
    private int _quantidade;

    public Produto(string nome, string id, double preco, int quantidade)
    {
        _nome = nome;
        _id = id;
        _preco = preco;
        _quantidade = quantidade;
    }

    public double CalcularCustoTotal()
    {
        return _preco * _quantidade;
    }

    public string ObterNome()
    {
        return _nome;
    }

    public string ObterId()
    {
        return _id;
    }

    public double ObterPreco()
    {
        return _preco;
    }

    public int ObterQuantidade()
    {
        return _quantidade;
    }
}