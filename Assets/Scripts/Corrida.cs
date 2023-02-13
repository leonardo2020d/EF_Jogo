using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrida : MonoBehaviour
{

    public GameObject car;
    public  Transform destino;
    private void Start()
    {
        
    }

    void Update()
    {
        if (GameEvents.instance.pegouPassageiro == true)
        {
            
            if (Vector3.Distance(car.transform.position, destino.position) < 2f)
            {
                GameEvents.instance.Dinheiro  +=Random.Range(5, 15);
                GameEvents.instance.pegouPassageiro = false;

            }
        }
    }
}
