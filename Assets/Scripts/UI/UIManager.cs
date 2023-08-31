using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject menuOpcoes;
    public TextMeshProUGUI dinheiro;
    public GameObject hudCarro;
  


    private bool menuAberto = false;

    private void Start()
    {
        dinheiro.text = GameEvents.instance.Dinheiro.ToString();
        hudCarro.SetActive(false);
        GameEvents.instance.OninterfaceCar += interfaceCarro;
    }

    private void Update()
    {
        // Verifique se a tecla Esc foi pressionada para abrir ou fechar o menu de opções
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuAberto)
                FecharMenuOpcoes();
            else
                AbrirMenuOpcoes();
        }
     
    }

    public void AbrirMenuOpcoes()
    {
        menuOpcoes.SetActive(true);
        menuAberto = true;
       // Cursor.lockState = CursorLockMode.None;
     //   Cursor.visible = true;
       
    }
    public void interfaceCarro(bool entrouCarro)
    {
        if (entrouCarro == true)
        {
            hudCarro.gameObject.SetActive(true);
        }
        else
        {
            hudCarro.gameObject.SetActive(false);
        }
    }
 
    public void FecharMenuOpcoes()
    {
        menuOpcoes.SetActive(false);
        menuAberto = false;
      //  Cursor.lockState = CursorLockMode.Locked;
      //  Cursor.visible = false;
    }
  

}
