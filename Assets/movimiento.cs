using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float moveSpeed = 12;
    Rigidbody rigidBody;
    float moveX;
    float moveZ;
    bool isTouching = false;
    public float jumpPower;
    public Transform _camera;
    public Vector3 moveVector;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();

        if (rigidBody == null)
            Debug.LogError("RigidBody could not be found.");
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        moveVector = new Vector3(transform.position.x * moveX, 0f, (transform.position.z - _camera.GetComponent<Camera>().transform.position.z) * moveZ);
    }



    public void FixedUpdate()
    {

        if (rigidBody != null)
        {
            rigidBody.AddForce(moveVector * moveSpeed, ForceMode.Acceleration);
        }
        if (isTouching && Input.GetKeyDown("space"))
        { //jump
            rigidBody.AddForce(new Vector3(0, jumpPower, 0) * 50, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isTouching = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isTouching = false;
    }
}
  
