using System;
using System.Collections.Generic;
using System.IO;

public class Diario
{
    private List<Registro> _registros = new List<Registro>();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    public void SalvarNoArquivo(string arquivo)
    {
        using (StreamWriter escritor = new StreamWriter(arquivo))
        {
            foreach (Registro registro in _registros)
            {
                escritor.WriteLine(
                    $"{registro._data}|{registro._textoPergunta}|{registro._textoResposta}"
                );
            }
        }
    }

    public void CarregarDoArquivo(string arquivo)
    {
        _registros.Clear();

        string[] linhas = File.ReadAllLines(arquivo);

        foreach (string linha in linhas)
        {
            string[] partes = linha.Split('|');

            string data = partes[0];
            string pergunta = partes[1];
            string resposta = partes[2];

            Registro registro = new Registro(data, pergunta, resposta);
            _registros.Add(registro);
        }
    }

    public int ObterQuantidadeRegistros()
    {
        return _registros.Count;
    }
}