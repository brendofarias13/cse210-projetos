using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video(
            "Aprendendo C#",
            "Brendo Farias",
            600
        );

        video1.AdicionarComentario(new Comentario(
            "João",
            "Excelente vídeo!"
        ));

        video1.AdicionarComentario(new Comentario(
            "Maria",
            "Aprendi bastante."
        ));

        video1.AdicionarComentario(new Comentario(
            "Carlos",
            "Muito bom!"
        ));


        Video video2 = new Video(
            "Programação Orientada a Objetos",
            "Curso de Programação",
            720
        );

        video2.AdicionarComentario(new Comentario(
            "Ana",
            "Gostei muito da explicação."
        ));

        video2.AdicionarComentario(new Comentario(
            "Pedro",
            "Esse conteúdo ajudou bastante."
        ));

        video2.AdicionarComentario(new Comentario(
            "Lucas",
            "Muito interessante."
        ));


        Video video3 = new Video(
            "Como Criar Classes em C#",
            "Programação Fácil",
            480
        );

        video3.AdicionarComentario(new Comentario(
            "Fernanda",
            "Ótimo conteúdo!"
        ));

        video3.AdicionarComentario(new Comentario(
            "Rafael",
            "Agora entendi classes."
        ));

        video3.AdicionarComentario(new Comentario(
            "Juliana",
            "Muito bem explicado."
        ));


        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };


        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Título: {video.GetTitulo()}");
            Console.WriteLine($"Autor: {video.GetAutor()}");
            Console.WriteLine($"Duração: {video.GetDuracao()} segundos");
            Console.WriteLine($"Número de comentários: {video.ObterNumeroDeComentarios()}");
            Console.WriteLine("Comentários:");

            foreach (Comentario comentario in video.GetComentarios())
            {
                Console.WriteLine(
                    $"- {comentario.GetNome()}: {comentario.GetTexto()}"
                );
            }

            Console.WriteLine();
        }
    }
}