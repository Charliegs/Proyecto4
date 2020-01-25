using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dedos : MonoBehaviour
{
    public float fuerza = 2500;
    Rigidbody rb;
    public bool tomado = false;

    public GameObject[] objetos;
    public GameObject objeto = null;
    public float distance = Mathf.Infinity;
    public Camera cam;


    void Start()
    {
        objetos = GameObject.FindGameObjectsWithTag("interac");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        foreach (GameObject go in objetos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                objeto = go;
                distance = curDistance;
            } 
        }
        tomar();
    }

    /*void OnCollisionEnter(Collision col)
    {
        if (!tomado && col.gameObject.tag == "interac" && Input.GetKey(KeyCode.E))
        {
            SpringJoint sp = gameObject.AddComponent<SpringJoint>();
            sp.connectedBody = col.rigidbody;
            sp.spring = 12000;
            sp.breakForce = fuerza;
            tomado = true;
        }
    }*/

    public void tomar()
    {
        if (!tomado && objeto.tag == "interac" && Input.GetKey(KeyCode.E) && distance <= 0.7f)
        {
            SpringJoint sp = gameObject.AddComponent<SpringJoint>();
            sp.connectedBody = objeto.GetComponent<Rigidbody>();
            sp.spring = 12000;
            sp.breakForce = fuerza;
            objeto.transform.position = this.transform.position;
            tomado = true;
        }
        if (tomado && Input.GetKey(KeyCode.Q))
        {
            Destroy(GetComponent<SpringJoint>());
            tomado = false;
        }

        if (!tomado)
        {
            Destroy(GetComponent<SpringJoint>());
        }
    }


    void OnJointBreak()
    {
        tomado = false;
    }
}
