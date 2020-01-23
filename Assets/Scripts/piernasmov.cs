using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piernasmov : MonoBehaviour {


    public HingeJoint Osso;
    public bool Inverter;
    public string NomeDoObj;

    void Update()
    {
        JointSpring Js = Osso.spring;

        Js.targetPosition = GameObject.Find(NomeDoObj).transform.localEulerAngles.x;

        if (Js.targetPosition > 180)
            Js.targetPosition = Js.targetPosition - 360;

        Js.targetPosition = Mathf.Clamp(Js.targetPosition, Osso.limits.min + 5, Osso.limits.max - 5);

        if (Inverter)
            Js.targetPosition = Js.targetPosition * -1;

        Osso.spring = Js;
    }
}