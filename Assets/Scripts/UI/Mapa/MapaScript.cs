using System.Collections.Generic;
using UnityEngine;

public class MapaScript : MonoBehaviour
{
    public Camera mapaCamera; // Refer�ncia para a c�mera do mapa
    public GameObject linhaPrefab; // Prefab de linha que ser� usada para representar o caminho
    private GameObject linhaObjeto; // Refer�ncia para o objeto de linha

    public List<PontoAcessivel> pontosAcessiveis; // Lista de todos os pontos acess�veis no seu grafo

    // Chame a fun��o para encontrar o ponto acess�vel mais pr�ximo para os pontos inicial e final
    private PontoAcessivel EncontrarPontoAcessivelMaisProximo(Vector3 ponto)
    {
        PontoAcessivel pontoMaisProximo = null;
        float distanciaMaisProxima = float.MaxValue;

        foreach (PontoAcessivel pontoAcessivel in pontosAcessiveis)
        {
            float distancia = Vector3.Distance(ponto, pontoAcessivel.position);

            if (distancia < distanciaMaisProxima)
            {
                distanciaMaisProxima = distancia;
                pontoMaisProximo = pontoAcessivel;
            }
        }

        return pontoMaisProximo;
    }

    // Implemente aqui o algoritmo A* para encontrar o caminho entre os pontos inicial e final no grafo
    private List<Vector3> AStarEncontrarCaminho(Vector3 pontoInicial, Vector3 pontoFinal)
    {
        PontoAcessivel pontoInicialAcessivel = EncontrarPontoAcessivelMaisProximo(pontoInicial);
        PontoAcessivel pontoFinalAcessivel = EncontrarPontoAcessivelMaisProximo(pontoFinal);

        // Chame o algoritmo A* para encontrar o caminho entre os pontos acess�veis
        return AStar.EncontrarCaminho(pontoInicialAcessivel, pontoFinalAcessivel);
    }

    // Fun��o que exibe o caminho no mapa
    public void MostrarCaminho(Vector3 pontoInicial, Vector3 pontoFinal)
    {
        // Use o algoritmo A* para encontrar o caminho completo entre os pontos inicial e final
        List<Vector3> caminhoPelosPontos = AStarEncontrarCaminho(pontoInicial, pontoFinal);

        // Se j� houver uma linha, destrua-a para criar uma nova
        if (linhaObjeto != null)
        {
            Destroy(linhaObjeto);
        }

        // Crie a linha usando o prefab
        linhaObjeto = Instantiate(linhaPrefab, Vector3.zero, Quaternion.identity);

        // Configure os v�rtices da linha com os pontos do caminho
        LineRenderer linhaRenderer = linhaObjeto.GetComponent<LineRenderer>();
        linhaRenderer.positionCount = caminhoPelosPontos.Count;
        linhaRenderer.SetPositions(caminhoPelosPontos.ToArray());

        // Certifique-se de que a linha seja vis�vel na c�mera do mapa
        linhaObjeto.transform.SetParent(mapaCamera.transform);
        linhaObjeto.transform.localPosition = Vector3.zero;
    }
}
