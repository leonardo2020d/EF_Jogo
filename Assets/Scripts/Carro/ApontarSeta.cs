using UnityEngine;

public class ApontarSeta : MonoBehaviour
{
    public Transform target; // A localiza��o para onde a seta deve apontar.

    void Update()
    {
        if (target != null)
        {
            // Calcula a dire��o do objeto atual para o destino.
            Vector3 direction = target.position - transform.position;

            // Calcula a rota��o necess�ria para que a seta aponte na dire��o desejada.
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Aplica a rota��o � seta.
            transform.rotation = rotation;
        }
    }
}
