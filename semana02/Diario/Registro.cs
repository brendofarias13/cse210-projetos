using System;

public class Registro
{
    public string _data = "";
    public string _textoPergunta = "";
    public string _textoResposta = "";

    public Registro(string data, string textoPergunta, string textoResposta)
    {
        _data = data;
        _textoPergunta = textoPergunta;
        _textoResposta = textoResposta;
    }

    public void Exibir()
    {
        Console.WriteLine($"Data: {_data}");
        Console.WriteLine($"Pergunta: {_textoPergunta}");
        Console.WriteLine($"Resposta: {_textoResposta}");
        Console.WriteLine();
    }
}