using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Vector3 posiInicial;
    public GameObject cadera;

    Rigidbody rb;
    CapsuleCollider caps;
    public float Resistencia = 10;
    public Animator anim;

    void Awake()
    {
        posiInicial = cadera.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > Resistencia)
        {
            caps.enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            anim.SetBool("golpeado", true);
            StartCoroutine(recuperacion());
        }
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        caps = GetComponent<CapsuleCollider>();
    }

    IEnumerator recuperacion()
    {
        yield return new WaitForSeconds(2);
        cadera.transform.position = posiInicial;
    }
}
