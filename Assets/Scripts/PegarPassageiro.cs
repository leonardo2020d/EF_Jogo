using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarPassageiro : MonoBehaviour
{
    public GameObject car;
   
    public GameObject civil;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            civil.transform.parent = car.transform;
            civil.SetActive(false);
            GameEvents.instance.pegouPassageiro=true;
        }
    }
    private void Update()
    {
        if (GameEvents.instance.pegouPassageiro == false)
        {
            civil.transform.parent = null;
            civil.SetActive(true);
          
        }
    }
}
