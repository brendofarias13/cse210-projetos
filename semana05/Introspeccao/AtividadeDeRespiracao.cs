using System;

public class AtividadeDeRespiracao : Atividade
{
    public AtividadeDeRespiracao()
    {
        _nome = "Respiração";
        _descricao = "Esta atividade ajudará você a relaxar, " +
                     "inspirando e expirando lentamente. " +
                     "Limpe sua mente e concentre-se na sua respiração.";
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        int tempoPassado = 0;
        int intervalo = 4;

        while (tempoPassado < _duracao)
        {
            Console.WriteLine("Inspire...");
            
            int tempo = Math.Min(intervalo, _duracao - tempoPassado);
            ExibirContagemRegressiva(tempo);
            tempoPassado += tempo;

            if (tempoPassado >= _duracao)
            {
                break;
            }

            Console.WriteLine("Expire...");

            tempo = Math.Min(intervalo, _duracao - tempoPassado);
            ExibirContagemRegressiva(tempo);
            tempoPassado += tempo;
        }

        ExibirMensagemFinal();
    }
}