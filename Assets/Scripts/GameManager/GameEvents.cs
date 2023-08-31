using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
  public static GameEvents instance;
    private void Awake() => instance=this;

    public event Action Onpause;
    public void Pause ()=>Onpause?.Invoke();

    public event Action OnDespause;
    public void Despause()=>OnDespause?.Invoke();
    public event Action<bool> OninterfaceCar;
    public void interfaceCar(bool entrouNoCarro) => OninterfaceCar(entrouNoCarro);
    public GameObject camVeiculo;
    public bool estaCarro;
    public float Dinheiro = 500;
    public bool pegouPassageiro;
   
    
 

    public enum Estado{
        Pausado,EmJogo
    }
    public Estado estadoDoJogo = Estado.EmJogo;
    public bool pausado;
    public List<Passageiro> passageiros = new List<Passageiro>();

    public GerenciadorBotoes gerenciadorBotoes;
    private void Start()
    {
        gerenciadorBotoes.CriarBotoes(passageiros);

    }

}
