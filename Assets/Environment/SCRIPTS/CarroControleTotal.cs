using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();
        corpoRigido.mass = peso;

        
    }


    void Update()
    {
            direcao = Input.GetAxis("Horizontal");
            if (direcao > 0.7f || direcao < 0.7f)
            {
                angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 4);
            }
            else
            {
                angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 2);
            }
        
        velocidade = corpoRigido.velocity.magnitude * 3.6f;
    }
    private void FixedUpdate()
    {
        rodasCollider[0].steerAngle = angulo * 40;
        rodasCollider[1].steerAngle = angulo * 40;
        rodasCollider[2].motorTorque = Input.GetAxis("Vertical") * torque * Time.deltaTime;
        rodasCollider[3].motorTorque = Input.GetAxis("Vertical") * torque * Time.deltaTime;

        for (int i = 0; i < rodasCollider.Length; i++)
        {
            Vector3 pos;
            Quaternion rot;
            rodasCollider[i].GetWorldPose(out pos, out rot);
            rodasMesh[i].position = pos;
            rodasMesh[i].rotation = rot;
        }
       
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
                print("AAAAAAAAAAAa");
                rodasCollider[2].brakeTorque = 0;
                rodasCollider[3].brakeTorque = 0;
            }
    }
}
