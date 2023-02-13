using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntarCarro : MonoBehaviour
{
    public GameObject player;
    public GameObject carro;
    public GameObject cameraCAr;

    private void Update()
    {
        if (GameEvents.instance.estaCarro == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                GameEvents.instance.estaCarro = false;
                player.SetActive(true);
                cameraCAr.SetActive(false);
                player.transform.parent=null;

            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.parent = carro.transform;
                GameEvents.instance.estaCarro = true;
                player.SetActive(false);
                cameraCAr.SetActive(true);
           
                
            }
        }
    }

}
