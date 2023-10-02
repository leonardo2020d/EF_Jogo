using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject menuOpcoes;

    public GameObject hudCarro;

    public int lucroFase;
    public GameObject panelPf;
    public GameObject panelRestart;
    public TextMeshProUGUI corridasConcluidas;
    public int totalCorridas;

    private bool menuAberto = false;

    private void Start()
    {
      
        hudCarro.SetActive(false);
        GameEvents.instance.OninterfaceCar += interfaceCarro;
        GameEvents.instance.OnEndPhase += EncerrarPhase;
        GameEvents.instance.OnEndRun += ConcluiuCorrida;
        panelRestart.SetActive(false);
        panelPf.SetActive(false);
        corridasConcluidas.text = GameEvents.instance.Corridasconcludas.ToString() + "/" + totalCorridas;
    }

    private void Update()
    {

        if (GameEvents.instance.pegouPassageiro == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (menuAberto)
                    FecharMenuOpcoes();
                else
                    AbrirMenuOpcoes();
            }
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
    public void EncerrarPhase()
    {
        if (GameEvents.instance.VerificaLucro() >= lucroFase)
        {
            panelPf.SetActive(true);
        }
        else
        {
            panelPf.SetActive(false);
        }
    }
    public void ConcluiuCorrida()
    {
        corridasConcluidas.text = GameEvents.instance.Corridasconcludas.ToString() + "/" + totalCorridas;
    }


}
