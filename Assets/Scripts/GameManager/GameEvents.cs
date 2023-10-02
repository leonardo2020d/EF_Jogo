using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

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
    public bool podeDescer;
    public int Corridasconcludas=0;
    private float dinInicial;
   


    public event Action OnAbastecer;
    public void Abastacer() => OnAbastecer?.Invoke();
    public event Action OnEndPhase;
    public void EndPhase() => OnEndPhase?.Invoke();


    public enum Estado{
        Pausado,EmJogo
    }
    public Estado estadoDoJogo = Estado.EmJogo;
    public bool pausado;
    public List<Passageiro> passageiros = new List<Passageiro>();

    public GerenciadorBotoes gerenciadorBotoes;
    private void Start()
    {
        dinInicial = Dinheiro;
        gerenciadorBotoes.CriarBotoes(passageiros);

    }
    public void AceitouCorrida()
    {
        pegouPassageiro = true;
    }
    public void CarregarFase(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public float VerificaLucro()
    {
        return Dinheiro - dinInicial;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
