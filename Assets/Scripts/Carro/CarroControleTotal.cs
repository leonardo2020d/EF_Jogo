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
    public int DefinirCorridas;
 
    private bool temPassageiro = false;

   
    private float gasTotal = 10;
    private float gasAtual;
    [SerializeField] private Gas barraGas;

    private Vector3 startPosition; // A posição inicial do objeto.
    private float distanciaPercorrida; 
    private float distanciaPercorridaTotal;
    public ApontarSeta seta;
 
  
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();
        corpoRigido.mass = peso;
        startPosition = transform.position;
        gasAtual = gasTotal;

        barraGas.ConsumiuGasolina(gasAtual, gasTotal);
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
        else
        {
            seta.gameObject.SetActive(false);
        }

        if (GameEvents.instance.Corridasconcludas == DefinirCorridas)
        {
            GameEvents.instance.EndPhase();
        }
    }
    private void FixedUpdate()
    {
        velocidade = corpoRigido.velocity.magnitude * 3.6f;
        if (GameEvents.instance.estaCarro == true)
        {
            if (velocidade <= 0.2f)
            {
                GameEvents.instance.podeDescer = true;
            }
            else
            {
                GameEvents.instance.podeDescer = false;
            }
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
                distanciaPercorrida = Vector3.Distance(startPosition, transform.position);
                distanciaPercorridaTotal += distanciaPercorrida;
                if(distanciaPercorridaTotal >= 1000000)
                {
                    gasAtual -=1;
                    barraGas.ConsumiuGasolina(gasAtual, gasTotal);
                    distanciaPercorridaTotal = 0;
                    print("zerou");
                }
                
                
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
        GameEvents.instance.pegouPassageiro = true;

        passageiro.gameObject.SetActive(false);
        seta.target = passageiroAtual.passageiroAtual.destino;
        seta.gameObject.SetActive(true);

        

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
         
            
            GameEvents.instance.pegouPassageiro = false;
            GameEvents.instance.Corridasconcludas = +1;
            GameEvents.instance.EndRun();
         
            passageiroAtual.passageiroAtual = null;
           
          
            
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
                other.gameObject.SetActive(false);
                seta.gameObject.SetActive(false);
                GameEvents.instance.passageiros.RemoveAt(GameEvents.instance.gerenciadorBotoes.passageiroAtual.id);
                GameEvents.instance.gerenciadorBotoes.LimparBotoes();
                GameEvents.instance.gerenciadorBotoes.CriarBotoes(GameEvents.instance.passageiros);
               
            }
        }
    }
}
