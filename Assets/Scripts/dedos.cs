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
    public float distance;
    public Camera cam;

    public GameObject vacioObject;


    public bool derecha = false;


    void Start()
    {
        if (this.name == "dedos_derecho")
        {
            derecha = true;
        }
        else { derecha = false; }

        objetos = GameObject.FindGameObjectsWithTag("interac");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 position = transform.position;
        foreach (GameObject go in objetos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                objeto = go;
                distance = curDistance;
            }
        }*/
        float nearestDistance = float.MaxValue;

        foreach (GameObject go in objetos)
        {
            distance = (gameObject.transform.position - go.transform.position).sqrMagnitude; 
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                objeto = go;
            }
        }

        tomar();
    }

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
