
using System;
using System.Collections.Generic;
using System.IO;

class GerenciadorDeMetas
{
    private List<Meta> _metas;
    private int _pontuacao;
    private string _arquivo;

    public int Pontuacao
    {
        get { return _pontuacao; }
    }

    public GerenciadorDeMetas()
    {
        _metas = new List<Meta>();
        _pontuacao = 0;
        _arquivo = "metas.txt";
    }

    public string ObterNivel()
    {
        int nivel = (_pontuacao / 500) + 1;
        return nivel.ToString();
    }

    public string ObterTitulo()
    {
        if (_pontuacao >= 5000)
        {
            return "Mestre das Metas";
        }

        if (_pontuacao >= 2500)
        {
            return "Especialista";
        }

        if (_pontuacao >= 1000)
        {
            return "Comprometido";
        }

        if (_pontuacao >= 500)
        {
            return "Iniciante Dedicado";
        }

        return "Começando a Jornada";
    }

    public void MostrarMetas()
    {
        Console.WriteLine("\n=== MINHAS METAS ===");

        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }

        for (int i = 0; i < _metas.Count; i++)
        {
            Meta meta = _metas[i];

            Console.WriteLine($"{i + 1}. {meta.ObterStatus()} {meta.Nome}");
            Console.WriteLine($"   Tipo: {meta.ObterTipo()}");
            Console.WriteLine($"   Descrição: {meta.Descricao}");
            Console.WriteLine($"   Pontos por registro: {meta.Pontos}");

            string progresso = meta.ObterDescricaoProgresso();

            if (!string.IsNullOrWhiteSpace(progresso))
            {
                Console.WriteLine($"   {progresso}");
            }

            Console.WriteLine();
        }

        Console.WriteLine($"Pontuação total: {_pontuacao}");
        Console.WriteLine($"Nível: {ObterNivel()}");
        Console.WriteLine($"Título: {ObterTitulo()}");
    }

    public void CriarMeta()
    {
        Console.WriteLine("\n=== CRIAR NOVA META ===");
        Console.WriteLine("1. Meta simples");
        Console.WriteLine("2. Meta eterna");
        Console.WriteLine("3. Meta checklist");
        Console.Write("Escolha o tipo: ");

        string tipo = Console.ReadLine() ?? "";

        if (tipo != "1" && tipo != "2" && tipo != "3")
        {
            Console.WriteLine("Tipo de meta inválido.");
            return;
        }

        Console.Write("Nome da meta: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Descrição da meta: ");
        string descricao = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("O nome da meta não pode ficar vazio.");
            return;
        }

        Console.Write("Pontos por registro: ");

        if (!int.TryParse(Console.ReadLine(), out int pontos) || pontos <= 0)
        {
            Console.WriteLine("Digite uma quantidade de pontos maior que zero.");
            return;
        }

        Meta? novaMeta = null;

        switch (tipo)
        {
            case "1":
                novaMeta = new MetaSimples(nome, descricao, pontos);
                break;

            case "2":
                novaMeta = new MetaEterna(nome, descricao, pontos);
                break;

            case "3":
                Console.Write("Quantas vezes precisa ser realizada? ");

                if (!int.TryParse(Console.ReadLine(), out int quantidade)
                    || quantidade <= 0)
                {
                    Console.WriteLine("A quantidade deve ser maior que zero.");
                    return;
                }

                Console.Write("Bônus de pontos ao completar: ");

                if (!int.TryParse(Console.ReadLine(), out int bonus)
                    || bonus < 0)
                {
                    Console.WriteLine("O bônus não pode ser negativo.");
                    return;
                }

                novaMeta = new MetaChecklist(
                    nome,
                    descricao,
                    pontos,
                    quantidade,
                    bonus
                );
                break;
        }

        if (novaMeta != null)
        {
            _metas.Add(novaMeta);
            Console.WriteLine("Meta criada com sucesso!");
        }
    }

    public void RegistrarProgresso()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Você ainda não cadastrou nenhuma meta.");
            return;
        }

        Console.WriteLine("\n=== REGISTRAR PROGRESSO ===");

        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_metas[i].Nome} ({_metas[i].ObterTipo()})"
            );
        }

        Console.Write("Escolha o número da meta: ");

        if (!int.TryParse(Console.ReadLine(), out int escolha)
            || escolha < 1
            || escolha > _metas.Count)
        {
            Console.WriteLine("Número de meta inválido.");
            return;
        }

        int pontosGanhos = _metas[escolha - 1].Registrar();
        _pontuacao += pontosGanhos;

        Console.WriteLine($"Pontuação total: {_pontuacao}");
        Console.WriteLine($"Nível atual: {ObterNivel()}");
        Console.WriteLine($"Título atual: {ObterTitulo()}");
    }

    public void Salvar()
    {
        try
        {
            List<string> linhas = new List<string>
            {
                $"P|{_pontuacao}"
            };

            foreach (Meta meta in _metas)
            {
                linhas.Add(meta.ObterDados());
            }

            File.WriteAllLines(_arquivo, linhas);

            Console.WriteLine("Metas, progresso e pontuação salvos com sucesso!");
        }
        catch (IOException)
        {
            Console.WriteLine("Erro ao salvar o arquivo de metas.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Sem permissão para salvar o arquivo.");
        }
    }

    public void Carregar()
    {
        if (!File.Exists(_arquivo))
        {
            Console.WriteLine("Arquivo de metas ainda não existe. Começando uma nova lista.");
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
                {
                    continue;
                }

                string[] partes = linha.Split('|');

                if (partes[0] == "P" && partes.Length >= 2)
                {
                    if (int.TryParse(partes[1], out int pontuacao))
                    {
                        pontuacaoCarregada = pontuacao;
                    }

                    continue;
                }

                Meta? meta = Meta.CriarAPartirDoArquivo(linha);

                if (meta != null)
                {
                    metasCarregadas.Add(meta);
                }
            }

            _metas = metasCarregadas;
            _pontuacao = pontuacaoCarregada;

            Console.WriteLine("Metas e progresso carregados com sucesso!");
        }
        catch (IOException)
        {
            Console.WriteLine("Erro ao ler o arquivo de metas.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Sem permissão para ler o arquivo.");
        }
    }
}
