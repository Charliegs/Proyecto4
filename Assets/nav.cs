using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nav : MonoBehaviour
{
    public Transform goal;

    void Update()
    {
        float step = 1.0f * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, goal.transform.position, step);
    }
}

