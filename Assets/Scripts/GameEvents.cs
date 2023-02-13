using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
  public static GameEvents instance;
    private void Awake() => instance=this;

    public event Action  OnInfracao;
    public void Infracao() => OnInfracao?.Invoke();

    public event Action Onpause;
    public void Pause ()=>Onpause?.Invoke();

    public event Action OnDespause;
    public void Despause()=>OnDespause?.Invoke();

    public event Action<string, string, string, Sprite> OnAtivaMsg;
    public void AtivaMsg(string msg="",string titulo ="", string atalho="", Sprite img=null)=>OnAtivaMsg?.Invoke(msg, titulo, atalho, img);

    public event Action<string, string, string, Sprite> OnDesativaMsg;
    public void DesativaMsg(string msg="",string titulo="",string atalho="",Sprite img=null)=>OnDesativaMsg?.Invoke(msg, titulo,atalho, img);
    public event Action OnCheckpoint;
    public GameObject camVeiculo;
    public bool estaCarro;

    
 
    public void Checkpoint ( )=>OnCheckpoint?.Invoke();
    public event Action OnDesativaIK;
    public void DesativaIk()=>OnDesativaIK?.Invoke();
    public event Action OnPauseMenu;
    public void PauseMenu()=>OnPauseMenu?.Invoke();
    public int Dinheiro = 500;
    public bool pegouPassageiro;
    public bool isCutscene;
    
 

    public enum Estado{
        Pausado,EmJogo
    }
    public Estado estadoDoJogo = Estado.EmJogo;
    public bool pausado;

}
