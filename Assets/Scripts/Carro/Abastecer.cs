using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abastecer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            GameEvents.instance.Abastacer();
            
        }
    }
}
