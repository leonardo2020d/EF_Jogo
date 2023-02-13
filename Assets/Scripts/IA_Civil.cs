using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IA_Civil : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 tamanho;
    private Vector3 centro;
    private float tempoParado;

    bool primeira = false;

    void Start()
    {
        agent.GetComponent<NavMeshAgent>();
        centro = transform.position;
        
    }
    void Update()
    {
        if (agent.destination == null)
        {
            NovaDirecao();

        }
        if (agent.remainingDistance <= 0.2f)
        {
            NovaDirecao();
        }

           
    }
    public void NovaDirecao()
    {
        Vector3 pos = centro + new Vector3(Random.Range(-tamanho.x, tamanho.x), Random.Range(-tamanho.y, tamanho.y), Random.Range(-tamanho.z, tamanho.z));
        agent.destination = pos;   
    }
}
