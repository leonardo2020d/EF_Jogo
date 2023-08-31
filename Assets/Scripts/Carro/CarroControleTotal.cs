using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class CarroControleTotal : MonoBehaviour
{
    public Transform[] rodasMesh;
    public WheelCollider[] rodasCollider;
    float direcao;
    public float torque = 200;
    private Rigidbody corpoRigido;
    public float peso = 1500;
    public float velocidade;
    float angulo;
    public float forcaFreio = 100;
    public GerenciadorBotoes passageiroAtual;
 
    private bool temPassageiro = false;

    public float alcanceParaPegarPassageiro = 2f;


    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();
        corpoRigido.mass = peso;
        


    }



    void Update()
    {

        if (GameEvents.instance.estaCarro == true)
        {
            direcao = Input.GetAxis("Horizontal");

            if (direcao > 0 || direcao < 0)
            {
                angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 4);
            }
            else
            {
                angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 2);
            }
        }
        velocidade = corpoRigido.velocity.magnitude * 3.6f;
      
    }
    private void FixedUpdate()
    {
        if (GameEvents.instance.estaCarro == true)
        {
            rodasCollider[0].steerAngle = angulo * 40;
            rodasCollider[1].steerAngle = angulo * 40;
            rodasCollider[2].motorTorque = Input.GetAxis("Vertical") * torque * Time.deltaTime;
            rodasCollider[3].motorTorque = Input.GetAxis("Vertical") * torque * Time.deltaTime;
        }
        for (int i = 0; i < rodasCollider.Length; i++)
        {
            Vector3 pos;
            Quaternion rot;
            rodasCollider[i].GetWorldPose(out pos, out rot);
            rodasMesh[i].position = pos;
            rodasMesh[i].rotation = rot;
        }
        if (GameEvents.instance.estaCarro == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rodasCollider[2].brakeTorque = forcaFreio;
                rodasCollider[3].brakeTorque = forcaFreio;

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rodasCollider[2].brakeTorque = 0;
                rodasCollider[3].brakeTorque = 0;
            }
            if (Input.GetAxis("Vertical") != 0)
            {
                rodasCollider[2].brakeTorque = 0;
                rodasCollider[3].brakeTorque = 0;
            }

        }
        else
        {
            rodasCollider[2].brakeTorque = forcaFreio;
            rodasCollider[3].brakeTorque = forcaFreio;
        }

    }
    public void PegarPassageiro(Passageiro passageiro)
    {
        passageiroAtual.passageiroAtual = passageiro;
        temPassageiro = true;

        passageiro.gameObject.SetActive(false);
        

    }
   
    public void PassageiroEntregue()
    {

        if (passageiroAtual != null)
        {
            GameEvents.instance.Dinheiro += passageiroAtual.passageiroAtual.preco;
          //Destroy(passageiroAtual.passageiroAtual.destino);
            temPassageiro = false;
            passageiroAtual.passageiroAtual.transform.position = passageiroAtual.passageiroAtual.destino.position;
            passageiroAtual.passageiroAtual.gameObject.SetActive(true);
            passageiroAtual.passageiroAtual.transform.GetChild(0).gameObject.SetActive(false);
            passageiroAtual.passageiroAtual.transform.GetChild(1).gameObject.SetActive(false);
          
            passageiroAtual = null;
        }
      


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Passageiro"))
        {
       
            if (velocidade < 1&& passageiroAtual.passageiroAtual.corridaAceita==true )
            {
                PegarPassageiro(passageiroAtual.passageiroAtual);
            }
            else
            {
                print("passageiro errado");
            }
        }
        if (other.gameObject.CompareTag("Destino"))
        {
           
            if (velocidade < 1 && temPassageiro)
            {
                PassageiroEntregue();
                print("A");
            }
        }
    }
}
