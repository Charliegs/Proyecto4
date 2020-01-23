using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dedos : MonoBehaviour
{
    public float fuerza = 2500;
    Rigidbody rb;
    bool tomado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision col)
    {
        if (!tomado)
        {
            SpringJoint sp = gameObject.AddComponent<SpringJoint>();
            sp.connectedBody = col.rigidbody;
            sp.spring = 12000;
            sp.breakForce = fuerza;
            tomado = true;
        }
    }

    void OnJointBreak()
    {
        tomado = false;
    }
}
