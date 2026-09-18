using System;
using System.Collections.Generic;

public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras;

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = new List<Palavra>();

        string[] palavras = texto.Split(' ');

        foreach (string palavra in palavras)
        {
            _palavras.Add(new Palavra(palavra));
        }
    }

    public void EsconderPalavras(int quantidade)
    {
        Random random = new Random();

        for (int i = 0; i < quantidade; i++)
        {
            List<int> disponiveis = new List<int>();

            for (int j = 0; j < _palavras.Count; j++)
            {
                if (!_palavras[j].EstaEscondida())
                {
                    disponiveis.Add(j);
                }
            }

            if (disponiveis.Count == 0)
            {
                return;
            }

            int indice = disponiveis[random.Next(disponiveis.Count)];

            _palavras[indice].Esconder();
        }
    }

    public bool TodasPalavrasEscondidas()
    {
        foreach (Palavra palavra in _palavras)
        {
            if (!palavra.EstaEscondida())
            {
                return false;
            }
        }

        return true;
    }

    public string ObterTexto()
    {
        string texto = "";

        foreach (Palavra palavra in _palavras)
        {
            texto += palavra.ObterTexto() + " ";
        }

        return $"{_referencia.ObterTexto()} - {texto.Trim()}";
    }
}