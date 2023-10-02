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
    public float valorAsomar;
    public int id;

    
    private void Start()
    {
        
        distancia = Vector3.Distance(destino.position, transform.position);
       
        preco = (distancia / 100) *valorAsomar;
    }
}
