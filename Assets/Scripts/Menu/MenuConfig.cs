using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConfig : MonoBehaviour
{
   
   public void CarregarCena(string name ){
    SceneManager.LoadScene(name);
   }
   public void Sair (){
    Application.Quit();
    print ("S");
   }
   
}
