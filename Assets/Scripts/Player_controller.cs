using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Quaternion posiInicial;
    public GameObject cadera;

    Rigidbody rb;
    CapsuleCollider caps;
    public float Resistencia = 10;
    public Animator anim;
    public bool puedeCaer = true;

    void Awake()
    {
        puedeCaer = true;
        posiInicial = cadera.transform.rotation;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > Resistencia && puedeCaer == true)
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
        puedeCaer = false;
        yield return new WaitForSeconds(2);
        cadera.transform.position += transform.TransformDirection(Vector3.up * 2);
        cadera.transform.rotation = posiInicial;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        caps.enabled = true;
        anim.SetBool("golpeado", false);
        yield return new WaitForSeconds(2);
        puedeCaer = true;
    }
}
