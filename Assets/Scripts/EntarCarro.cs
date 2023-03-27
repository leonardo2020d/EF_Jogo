using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntarCarro : MonoBehaviour
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                GameEvents.instance.estaCarro = false;
                player.SetActive(true);
                cameraCAr.SetActive(false);
                player.transform.parent=null;

            }
        }
        else{
            if(distance < 2)
            {
                panel.SetActive(true);
                 if (Input.GetKey(KeyCode.E))
                  {
                player.transform.parent = carro.transform;
                GameEvents.instance.estaCarro = true;
                player.SetActive(false);
                cameraCAr.SetActive(true);
                 }
              

            }
              else
                {
                    panel.SetActive(false);
                }
        }
    }

}
