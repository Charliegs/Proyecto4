using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public camera cam;
    public GameObject humano;
    Transform posi;
    Rigidbody rb;
    CapsuleCollider caps;
    public HingeJoint[] MorteJoint;
    [Space(20)]
    public CapsuleCollider collcap;

    public Quaternion rotacion;

    public HingeJoint hj1, hj2;
    public JointSpring hs1, hs2;
    public float SpringMin = 30, SpringMax = 300;

    [Space(20)]
    public float Resistencia = 10;
    public Animator anim;
    bool Morto = false;
    public float Velocidade;

    [Space(20)]
    public bool AtivarAutoConserto;
    public Transform checkRootable;
    public bool Corrigindo;
    public float MinRoot, MaxRoot;
    public float Inclinaçao;
    private bool prefeiçao;
    private float pretime;



    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > Resistencia)
        {
            caps.enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            for (int x = 0; x < MorteJoint.Length; x++)
            {
                MorteJoint[x].useSpring = false;
            }
            anim.SetBool("golpeado", true);
            Morto = true;
        }
    }

    private void Awake()
    {
        Velocidade = GetComponent<Rigidbody>().velocity.magnitude;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        caps = GetComponent<CapsuleCollider>();
        prefeiçao = true;

        hs1 = hj1.spring;
        hs2 = hj2.spring;
    }


    void Update()
    {
        if (!Morto)
        {

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                rb.velocity = transform.forward * 10;
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = transform.forward * 5;

                anim.SetBool("golpeado", false);

                hs1.spring = SpringMin;
                hs2.spring = SpringMin;
                rb.AddForce(transform.forward * -1, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = cam.transform.forward * 5;

                anim.SetBool("golpeado", false);

                hs1.spring = SpringMin;
                hs2.spring = SpringMin;

                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(120 * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(-120 * Time.deltaTime, 0, 0);
                }
            }

            if (Input.GetKey(KeyCode.W) == false && Corrigindo == false)
            {
                anim.SetBool("golpeado", true);

                hs1.spring = SpringMax;
                hs2.spring = SpringMax;
            }
            if (Input.GetKey(KeyCode.S))
            {

            }

            if (Input.GetKey(KeyCode.A))
            {

            }
            if (Input.GetKey(KeyCode.D))
            {

            }
            hj1.spring = hs1;
            hj2.spring = hs2;
        }
    }
}
