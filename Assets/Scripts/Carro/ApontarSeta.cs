using UnityEngine;

public class ApontarSeta : MonoBehaviour
{
    public Transform target; // A localização para onde a seta deve apontar.

    void Update()
    {
        if (target != null)
        {
            // Calcula a direção do objeto atual para o destino.
            Vector3 direction = target.position - transform.position;

            // Calcula a rotação necessária para que a seta aponte na direção desejada.
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Aplica a rotação à seta.
            transform.rotation = rotation;
        }
    }
}
