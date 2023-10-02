using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gas : MonoBehaviour
{
    [SerializeField] private  Image barraGas;
    public GameObject panelAbastecer;
    public GameObject panelGasFull;
    public TextMeshProUGUI valorGas;
    public TextMeshProUGUI dinheiro;
    public int valor;
    public GameObject panelSemdin;
    void Start()
    {
        GameEvents.instance.OnAbastecer += PodeAbastecer;
        panelAbastecer.SetActive(false);
        
    }
    private void Update()
    {
        dinheiro.text = GameEvents.instance.Dinheiro.ToString();
    }
    public void ConsumiuGasolina(float barraAtual,float barraTotal)
    {
        barraGas.fillAmount = (float) barraAtual / barraTotal;
    }
    public void PodeAbastecer()
    {
       
        if (barraGas.fillAmount == 1)
        {
            panelGasFull.SetActive (true);
        }
        else
        {
            panelAbastecer.SetActive(true);
            valor = ((int)((1 - barraGas.fillAmount) * 50));
            valorGas.text = valor.ToString()+"R$";
        }
    }
    public void Sim()
    {
        if (GameEvents.instance.Dinheiro > valor)
        {
            GameEvents.instance.Dinheiro -= valor;
            barraGas.fillAmount = 1;
            dinheiro.text = GameEvents.instance.Dinheiro.ToString();
        }
        else
        {
            panelSemdin.SetActive(true);
        }
       
    }
}
