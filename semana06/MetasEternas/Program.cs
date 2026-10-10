
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    // CRIATIVIDADE EXTRA:
    // Adicionei níveis a cada 500 pontos, títulos especiais,
    // bônus de conclusão para metas checklist e mensagens de conquista.
    // O programa também salva e recupera o progresso do usuário.

    static void Main(string[] args)
    {
        GerenciadorDeMetas gerenciador = new GerenciadorDeMetas();

        gerenciador.Carregar();

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n================================");
            Console.WriteLine("       METAS ETERNAS");
            Console.WriteLine("================================");
            Console.WriteLine($"Pontuação: {gerenciador.Pontuacao}");
            Console.WriteLine($"Nível: {gerenciador.Nivel} - {gerenciador.Titulo}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Mostrar metas");
            Console.WriteLine("2. Criar nova meta");
            Console.WriteLine("3. Registrar progresso");
            Console.WriteLine("4. Salvar progresso");
            Console.WriteLine("5. Carregar progresso");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    gerenciador.MostrarMetas();
                    break;
                case "2":
                    gerenciador.CriarMeta();
                    break;
                case "3":
                    gerenciador.RegistrarMeta();
                    break;
                case "4":
                    gerenciador.Salvar();
                    break;
                case "5":
                    gerenciador.Carregar();
                    break;
                case "6":
                    gerenciador.Salvar();
                    Console.WriteLine("Progresso salvo. Continue firme em suas metas!");
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}

abstract class Meta
{
    private string _nome;
    private string _descricao;
    private int _pontos;

    public string Nome => _nome;
    public string Descricao => _descricao;
    public int Pontos => _pontos;

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
        return EstaConcluida() ? "[X]" : "[ ]";
    }

    public virtual string ObterDescricaoProgresso()
    {
        return "";
    }

    protected string Codificar(string texto)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(texto));
    }

    protected static string Decodificar(string texto)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(texto));
    }

    protected string DadosComuns()
    {
        return $"{Codificar(_nome)}|{Codificar(_descricao)}|{_pontos}";
    }

    public static Meta CriarAPartirDoArquivo(string linha)
    {
        string[] partes = linha.Split('|');

        string nome = Decodificar(partes[1]);
        string descricao = Decodificar(partes[2]);
        int pontos = int.Parse(partes[3]);

        switch (partes[0])
        {
            case "S":
                return new MetaSimples(
                    nome, descricao, pontos,
                    bool.Parse(partes[4]));

            case "E":
                return new MetaEterna(nome, descricao, pontos);

            case "C":
                return new MetaChecklist(
                    nome, descricao, pontos,
                    int.Parse(partes[4]),
                    int.Parse(partes[5]),
                    int.Parse(partes[6]));

            default:
                throw new FormatException("Tipo de meta desconhecido.");
        }
    }
}

class MetaSimples : Meta
{
    private bool _concluida;

    public MetaSimples(
        string nome, string descricao, int pontos,
        bool concluida = false)
        : base(nome, descricao, pontos)
    {
        _concluida = concluida;
    }

    public override int Registrar()
    {
        if (_concluida)
        {
            Console.WriteLine("Essa meta já foi concluída.");
            return 0;
        }

        _concluida = true;
        Console.WriteLine("Parabéns! Você concluiu essa meta!");
        return Pontos;
    }

    public override bool EstaConcluida()
    {
        return _concluida;
    }

    public override string ObterTipo()
    {
        return "Meta simples";
    }

    public override string ObterDados()
    {
        return $"S|{DadosComuns()}|{_concluida}";
    }
}

class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
    }

    public override int Registrar()
    {
        Console.WriteLine("Ótimo trabalho! Continue perseverando.");
        return Pontos;
    }

    public override string ObterTipo()
    {
        return "Meta eterna";
    }

    public override string ObterDados()
    {
        return $"E|{DadosComuns()}";
    }

    public override string ObterStatus()
    {
        return "[∞]";
    }
}

class MetaChecklist : Meta
{
    private int _quantidadeDesejada;
    private int _bonus;
    private int _quantidadeConcluida;

    public MetaChecklist(
        string nome, string descricao, int pontos,
        int quantidadeDesejada, int bonus,
        int quantidadeConcluida = 0)
        : base(nome, descricao, pontos)
    {
        _quantidadeDesejada = quantidadeDesejada;
        _bonus = bonus;
        _quantidadeConcluida = quantidadeConcluida;
    }

    public override int Registrar()
    {
        if (EstaConcluida())
        {
            Console.WriteLine("Essa meta checklist já foi concluída!");
            return 0;
        }

        _quantidadeConcluida++;

        int pontosGanhos = Pontos;

        Console.WriteLine(
            $"Progresso: {_quantidadeConcluida}/{_quantidadeDesejada}");

        if (EstaConcluida())
        {
            pontosGanhos += _bonus;
            Console.WriteLine($"META CONCLUÍDA! Bônus de {_bonus} pontos!");
        }

        return pontosGanhos;
    }

    public override bool EstaConcluida()
    {
        return _quantidadeConcluida >= _quantidadeDesejada;
    }

    public override string ObterTipo()
    {
        return "Meta checklist";
    }

    public override string ObterStatus()
    {
        return EstaConcluida() ? "[X]" : "[ ]";
    }

    public override string ObterDescricaoProgresso()
    {
        return $"Concluída {_quantidadeConcluida}/{_quantidadeDesejada} vezes";
    }

    public override string ObterDados()
    {
        return $"C|{DadosComuns()}|{_quantidadeDesejada}|{_bonus}|{_quantidadeConcluida}";
    }
}

class GerenciadorDeMetas
{
    private List<Meta> _metas = new List<Meta>();
    private int _pontuacao = 0;
    private readonly string _arquivo = "metas.txt";

    public int Pontuacao => _pontuacao;
    public int Nivel => (_pontuacao / 500) + 1;

    public string Titulo
    {
        get
        {
            if (Nivel >= 10) return "Guardião Celestial";
            if (Nivel >= 7) return "Discípulo Dedicado";
            if (Nivel >= 5) return "Servo Fiel";
            if (Nivel >= 3) return "Buscador da Verdade";
            return "Aprendiz Eterno";
        }
    }

    public void MostrarMetas()
    {
        Console.WriteLine("\n--- SUAS METAS ---");

        if (_metas.Count == 0)
        {
            Console.WriteLine("Você ainda não cadastrou metas.");
            return;
        }

        for (int i = 0; i < _metas.Count; i++)
        {
            Meta meta = _metas[i];

            Console.WriteLine(
                $"{i + 1}. {meta.ObterStatus()} {meta.Nome} " +
                $"({meta.ObterTipo()})");

            Console.WriteLine($"   {meta.Descricao}");
            Console.WriteLine($"   Pontos por registro: {meta.Pontos}");

            string progresso = meta.ObterDescricaoProgresso();

            if (!string.IsNullOrEmpty(progresso))
            {
                Console.WriteLine($"   {progresso}");
            }
        }
    }

    public void CriarMeta()
    {
        Console.WriteLine("\nQual tipo de meta deseja criar?");
        Console.WriteLine("1. Meta simples");
        Console.WriteLine("2. Meta eterna");
        Console.WriteLine("3. Meta checklist");
        Console.Write("Escolha: ");

        string tipo = Console.ReadLine() ?? "";

        if (tipo != "1" && tipo != "2" && tipo != "3")
        {
            Console.WriteLine("Tipo inválido.");
            return;
        }

        Console.Write("Nome da meta: ");
        string nome = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("O nome não pode ficar vazio.");
            return;
        }

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine() ?? "";

        int pontos = LerInteiro("Pontos por conclusão/registro: ", 1);

        if (tipo == "1")
        {
            _metas.Add(new MetaSimples(nome, descricao, pontos));
        }
        else if (tipo == "2")
        {
            _metas.Add(new MetaEterna(nome, descricao, pontos));
        }
        else
        {
            int quantidade = LerInteiro("Quantas vezes deseja realizar a meta? ", 1);
            int bonus = LerInteiro("Quantos pontos de bônus ao concluir? ", 0);

            _metas.Add(
                new MetaChecklist(nome, descricao, pontos, quantidade, bonus));
        }

        Console.WriteLine("Meta cadastrada com sucesso!");
    }

    public void RegistrarMeta()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Cadastre uma meta primeiro.");
            return;
        }

        MostrarMetas();

        int escolha = LerInteiro("Número da meta para registrar: ", 1);

        if (escolha > _metas.Count)
        {
            Console.WriteLine("Número de meta inválido.");
            return;
        }

        int pontuacaoAnterior = _pontuacao;
        _pontuacao += _metas[escolha - 1].Registrar();

        int pontosGanhos = _pontuacao - pontuacaoAnterior;

        if (pontosGanhos > 0)
        {
            Console.WriteLine($"+{pontosGanhos} pontos!");
            Console.WriteLine($"Pontuação total: {_pontuacao}");

            if (pontuacaoAnterior / 500 < _pontuacao / 500)
            {
                Console.WriteLine($"NOVO NÍVEL! Você é {Titulo}!");
            }
        }
    }

    public void Salvar()
    {
        try
        {
            using (StreamWriter arquivo = new StreamWriter(_arquivo))
            {
                arquivo.WriteLine($"P|{_pontuacao}");

                foreach (Meta meta in _metas)
                {
                    arquivo.WriteLine(meta.ObterDados());
                }
            }

            Console.WriteLine($"Progresso salvo em {_arquivo}.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro ao salvar: {ex.Message}");
        }
    }

    public void Carregar()
    {
        if (!File.Exists(_arquivo))
        {
            Console.WriteLine("Nenhum arquivo salvo encontrado. Começando um novo jogo.");
            return;
        }

        try
        {
            string[] linhas = File.ReadAllLines(_arquivo);
            List<Meta> metasCarregadas = new List<Meta>();
            int pontuacaoCarregada = 0;

            foreach (string linha in linhas)
            {
                if (string.IsNullOrWhiteSpace(linha))
                    continue;

                string[] partes = linha.Split('|');

                if (partes[0] == "P")
                {
                    pontuacaoCarregada = int.Parse(partes[1]);
                }
                else
                {
                    metasCarregadas.Add(Meta.CriarAPartirDoArquivo(linha));
                }
            }

            _metas = metasCarregadas;
            _pontuacao = pontuacaoCarregada;

            Console.WriteLine("Progresso carregado com sucesso!");
        }
        catch (Exception ex) when (
            ex is IOException ||
            ex is FormatException ||
            ex is IndexOutOfRangeException ||
            ex is ArgumentException)
        {
            Console.WriteLine($"Não foi possível carregar o arquivo: {ex.Message}");
        }
    }

    private int LerInteiro(string mensagem, int minimo)
    {
        while (true)
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine() ?? "";

            if (int.TryParse(entrada, out int valor) && valor >= minimo)
            {
                return valor;
            }

            Console.WriteLine($"Digite um número inteiro maior ou igual a {minimo}.");
        }
    }
}
