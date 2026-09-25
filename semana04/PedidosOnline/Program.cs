using System;

class Program
{
    static void Main(string[] args)
    {
        // Primeiro cliente e endereço
        Endereco endereco1 = new Endereco(
            "Rua Principal, 100",
            "Açailândia",
            "MA",
            "Brasil"
        );

        Cliente cliente1 = new Cliente(
            "Brendo Farias",
            endereco1
        );

        // Primeiro pedido
        Pedido pedido1 = new Pedido(cliente1);

        Produto produto1 = new Produto(
            "Notebook",
            "P001",
            2500.00,
            1
        );

        Produto produto2 = new Produto(
            "Mouse sem fio",
            "P002",
            80.00,
            2
        );

        pedido1.AdicionarProduto(produto1);
        pedido1.AdicionarProduto(produto2);

        // Segundo cliente e endereço
        Endereco endereco2 = new Endereco(
            "Avenida Central, 250",
            "Imperatriz",
            "MA",
            "Brasil"
        );

        Cliente cliente2 = new Cliente(
            "Maria Silva",
            endereco2
        );

        // Segundo pedido
        Pedido pedido2 = new Pedido(cliente2);

        Produto produto3 = new Produto(
            "Teclado",
            "P003",
            150.00,
            1
        );

        Produto produto4 = new Produto(
            "Monitor",
            "P004",
            1200.00,
            1
        );

        pedido2.AdicionarProduto(produto3);
        pedido2.AdicionarProduto(produto4);

        // Exibição do primeiro pedido
        Console.WriteLine("========================================");
        Console.WriteLine("PEDIDO 1");
        Console.WriteLine("========================================");
        Console.WriteLine($"Custo total: R$ {pedido1.CalcularCustoTotal():F2}");
        Console.WriteLine();
        Console.WriteLine(pedido1.ObterEtiquetaDeEmbalagem());
        Console.WriteLine(pedido1.ObterEtiquetaDeEnvio());

        // Exibição do segundo pedido
        Console.WriteLine("========================================");
        Console.WriteLine("PEDIDO 2");
        Console.WriteLine("========================================");
        Console.WriteLine($"Custo total: R$ {pedido2.CalcularCustoTotal():F2}");
        Console.WriteLine();
        Console.WriteLine(pedido2.ObterEtiquetaDeEmbalagem());
        Console.WriteLine(pedido2.ObterEtiquetaDeEnvio());
    }
}