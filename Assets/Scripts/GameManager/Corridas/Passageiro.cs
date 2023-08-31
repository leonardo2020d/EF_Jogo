using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Passageiro : MonoBehaviour
{
    public string nome;
    public float preco;
    public float distancia;
    public Transform destino;
    public bool corridaAceita =false;
    
    private void Start()
    {
        distancia = Vector3.Distance(destino.position, transform.position);
        preco = (distancia / 1000) * Random.Range(0.5f,2f);
    }
}
