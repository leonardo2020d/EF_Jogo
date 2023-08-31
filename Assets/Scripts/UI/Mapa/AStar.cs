using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    public static List<Vector3> EncontrarCaminho(PontoAcessivel pontoInicial, PontoAcessivel pontoFinal)
    {
        List<Vector3> caminhoPelosPontos = new List<Vector3>();
        Dictionary<PontoAcessivel, PontoAcessivel> pais = new Dictionary<PontoAcessivel, PontoAcessivel>();
        Dictionary<PontoAcessivel, float> gScore = new Dictionary<PontoAcessivel, float>();
        Dictionary<PontoAcessivel, float> fScore = new Dictionary<PontoAcessivel, float>();

        List<PontoAcessivel> listaAberta = new List<PontoAcessivel> { pontoInicial };
        gScore[pontoInicial] = 0;
        fScore[pontoInicial] = HeuristicaDistancia(pontoInicial, pontoFinal);

        while (listaAberta.Count > 0)
        {
            PontoAcessivel atual = ObterMenorFScore(listaAberta, fScore);

            if (atual == pontoFinal)
            {
                caminhoPelosPontos = ReconstruirCaminho(pais, pontoFinal);
                break;
            }

            listaAberta.Remove(atual);

            foreach (PontoAcessivel vizinho in atual.conexoes)
            {
                float tentativaGScore = gScore[atual] + Vector3.Distance(atual.position, vizinho.position);

                if (!gScore.ContainsKey(vizinho) || tentativaGScore < gScore[vizinho])
                {
                    pais[vizinho] = atual;
                    gScore[vizinho] = tentativaGScore;
                    fScore[vizinho] = gScore[vizinho] + HeuristicaDistancia(vizinho, pontoFinal);

                    if (!listaAberta.Contains(vizinho))
                    {
                        listaAberta.Add(vizinho);
                    }
                }
            }
        }

        return caminhoPelosPontos;
    }

    private static PontoAcessivel ObterMenorFScore(List<PontoAcessivel> lista, Dictionary<PontoAcessivel, float> fScore)
    {
        float menorFScore = float.MaxValue;
        PontoAcessivel pontoMenorFScore = null;

        foreach (PontoAcessivel ponto in lista)
        {
            if (fScore.ContainsKey(ponto) && fScore[ponto] < menorFScore)
            {
                menorFScore = fScore[ponto];
                pontoMenorFScore = ponto;
            }
        }

        return pontoMenorFScore;
    }

    private static List<Vector3> ReconstruirCaminho(Dictionary<PontoAcessivel, PontoAcessivel> pais, PontoAcessivel pontoAtual)
    {
        List<Vector3> caminhoPelosPontos = new List<Vector3>();
        caminhoPelosPontos.Add(pontoAtual.position);

        while (pais.ContainsKey(pontoAtual))
        {
            pontoAtual = pais[pontoAtual];
            caminhoPelosPontos.Insert(0, pontoAtual.position);
        }

        return caminhoPelosPontos;
    }

    private static float HeuristicaDistancia(PontoAcessivel pontoA, PontoAcessivel pontoB)
    {
        // Use a distância euclidiana (distância em linha reta) como heurística
        return Vector3.Distance(pontoA.position, pontoB.position);
    }
}
