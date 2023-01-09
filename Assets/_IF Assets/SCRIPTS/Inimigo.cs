using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform player;
    public Transform inimigo;
    public Transform[] paredes;
    int paredeAtual;
    public float velocidadeInimigo;
    float distanciaParede;
    public float vidaInimigo = 10;
    public Transform paredeAbrir;
    public Transform paredeFechar;
    private bool entrou;

    

    void Start()
    {
        paredeAtual = Random.Range(0, paredes.Length);
    }

    void Update()
    {
        distanciaParede = Vector3.Distance(paredes[paredeAtual].transform.position, inimigo.position);

        if (entrou == true)
        {
         
            inimigo.Rotate(0, 0, +20);
            inimigo.LookAt(paredes[paredeAtual]);

            inimigo.position = Vector3.Lerp(inimigo.position, paredes[paredeAtual].transform.position, Time.deltaTime * velocidadeInimigo);
            
        }

        
        if (distanciaParede < 1 && vidaInimigo!=0)
        {
            inimigo.Rotate(0, 0, +20);
            inimigo.LookAt(paredes[paredeAtual]);
            inimigo.position = Vector3.Lerp(inimigo.position, paredes[paredeAtual].transform.position, Time.deltaTime * velocidadeInimigo);
            paredeAtual = Random.Range(0, paredes.Length);
            
            velocidadeInimigo+= 0.1f;
            vidaInimigo--;
        }
        
        
        if (vidaInimigo == 0)
        {
            inimigo.position = inimigo.position;
            paredeAbrir.position = Vector3.Lerp(paredeAbrir.position, new Vector3(paredeAbrir.position.x, 10,paredeAbrir.position.z ), Time.deltaTime);
            inimigo.GetComponent<MeshRenderer>().enabled = false;
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            
            entrou = true;
            
        }
    }
    
    

}
