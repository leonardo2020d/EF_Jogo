using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntarCarro : MonoBehaviour, IInteractable
{
    public GameObject player;
    public GameObject carro;
    public GameObject cameraCAr;
    public GameObject panel;
    public float distance;

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position,carro.transform.position);
        if (GameEvents.instance.estaCarro == true)
        {
            panel.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Q)&& GameEvents.instance.podeDescer==true)
            {
                GameEvents.instance.interfaceCar(false);
                GameEvents.instance.estaCarro = false;
                player.SetActive(true);
                cameraCAr.SetActive(false);
                player.transform.parent=null;

            }
        }
        else{
            if(distance > 2)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
            

        }
    }
    public void Interact()
    {

        GameEvents.instance.interfaceCar(true);
        player.transform.parent = carro.transform;
        GameEvents.instance.estaCarro = true;
        player.SetActive(false);
        cameraCAr.SetActive(true);
    }
}
