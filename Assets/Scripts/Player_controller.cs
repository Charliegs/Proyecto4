using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {

    Rigidbody rb;
    CapsuleCollider caps;
    public float Resistencia = 10;
    public Animator anim;

    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > Resistencia)
        {
            caps.enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            anim.SetBool("golpeado", true);
        }
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        caps = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
