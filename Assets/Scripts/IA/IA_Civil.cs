using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IA_Civil : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 tamanho;
    private Vector3 centro;
    public Animator anin;

    public bool andando = false;
    public float tempopraMudar;

    void Start()
    {
        agent.GetComponent<NavMeshAgent>();
        centro = transform.position;
        andando=true;
        
    }
    void Update()
    {
        
     
        if(andando==true){
             agent.speed=3.5f;
             anin.SetBool("Andando",true);
             tempopraMudar+=Time.deltaTime;
             if (agent.destination == null&& andando==true)
        {
           NovaDirecao();
          

        }
        if (agent.remainingDistance <= 0.2f)
        {
            NovaDirecao();
           
        }
            if(tempopraMudar>Random.Range(10,500)){
                 andando=false;
                 tempopraMudar=0;
            }
        }
        else{
            tempopraMudar+=Time.deltaTime;
              anin.SetBool("Andando",false);
              agent.speed=0;
              if(tempopraMudar>Random.Range(10,500)){
                andando=true;
                tempopraMudar=0;
            }
        }
        

           
    }
    public void NovaDirecao()
    {
        Vector3 pos = centro + new Vector3(Random.Range(-tamanho.x, tamanho.x), Random.Range(-tamanho.y, tamanho.y), Random.Range(-tamanho.z, tamanho.z));
        agent.destination = pos;   
       
    }
   
}
