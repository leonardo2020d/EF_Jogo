using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstabilizarVeiculo : MonoBehaviour
{
    public WheelCollider rodaTrasEsquerda;
    public WheelCollider rodaTrasDireita;
    float forca = 10000;
    float estabilidade = 400;
    private Rigidbody corpoRigido;
    private bool estaNochao1;
    private bool estaNochao2;
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();
        corpoRigido.centerOfMass += new Vector3(0, -0.3f, -0.3f);
    }

    void Update()
    {
        float forcaEsquerdaTras = 1;
        float forcaDireitaTras = 1;

        WheelHit hit;
        estaNochao1 = rodaTrasEsquerda.GetGroundHit(out hit);
        estaNochao2 = rodaTrasDireita.GetGroundHit(out hit);

        if (estaNochao1)
        {
            forcaEsquerdaTras = (-rodaTrasDireita.transform.InverseTransformPoint(hit.point).y - rodaTrasEsquerda.radius) / rodaTrasEsquerda.suspensionDistance;
        }
        if (estaNochao2)
        {
            forcaDireitaTras = (-rodaTrasEsquerda.transform.InverseTransformPoint(hit.point).y - rodaTrasDireita.radius) / rodaTrasDireita.suspensionDistance;
        }

        float antirollForce = (forcaEsquerdaTras - forcaDireitaTras) * forca;
        if (estaNochao1)
        {
            corpoRigido.AddForceAtPosition(rodaTrasEsquerda.transform.up * -antirollForce, rodaTrasEsquerda.transform.position);
        }
        if (estaNochao2)
        {
            corpoRigido.AddForceAtPosition(rodaTrasDireita.transform.up * -antirollForce, rodaTrasDireita.transform.position);

        }

    }
    private void FixedUpdate()
    {
        if (estaNochao1 || estaNochao2)
        {
            corpoRigido.AddForce(-transform.up * (5000 + estabilidade * Mathf.Abs((corpoRigido.velocity.magnitude*3.6f))));
        }
        corpoRigido.velocity = Vector3.ClampMagnitude(corpoRigido.velocity, 300);
    }
}
