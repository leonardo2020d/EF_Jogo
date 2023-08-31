using UnityEngine;

public class PontoAcessivel : MonoBehaviour
{
    public Vector3 position; // Posi��o do ponto no mundo do jogo
    public PontoAcessivel[] conexoes; // Array de pontos conectados a este ponto

    private void OnDrawGizmos()
    {
        // Desenha gizmos para visualizar as conex�es na cena do Unity
        Gizmos.color = Color.green;
        foreach (PontoAcessivel ponto in conexoes)
        {
            Gizmos.DrawLine(transform.position, ponto.transform.position);
        }
    }
}
