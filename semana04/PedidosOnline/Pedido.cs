using System.Collections.Generic;

public class Pedido
{
    private List<Produto> _produtos;
    private Cliente _cliente;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
        _produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }

    public double CalcularCustoTotal()
    {
        double total = 0;

        foreach (Produto produto in _produtos)
        {
            total += produto.CalcularCustoTotal();
        }

        double taxaEnvio;

        if (EhNosEUA())
        {
            taxaEnvio = 5;
        }
        else
        {
            taxaEnvio = 35;
        }

        return total + taxaEnvio;
    }

    public string ObterEtiquetaDeEmbalagem()
    {
        string etiqueta = "ETIQUETA DE EMBALAGEM\n";
        etiqueta += "--------------------------\n";

        foreach (Produto produto in _produtos)
        {
            etiqueta += $"{produto.ObterNome()} - Quantidade: {produto.ObterQuantidade()}\n";
        }

        return etiqueta;
    }

    public string ObterEtiquetaDeEnvio()
    {
        string etiqueta = "ETIQUETA DE ENVIO\n";
        etiqueta += "--------------------------\n";
        etiqueta += $"Nome: {_cliente.ObterNome()}\n";
        etiqueta += $"Endereço: {_cliente.ObterEndereco()}\n";

        return etiqueta;
    }

    private bool EhNosEUA()
    {
        return _cliente.EhNosEUA();
    }
}