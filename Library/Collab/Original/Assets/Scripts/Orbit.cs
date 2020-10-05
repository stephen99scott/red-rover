using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    const float G = 667.4f;
    public static List<Orbit> Orbitters;
    public Rigidbody rb;

    void FixedUpdate()
    {
        foreach (Orbit orbit in Orbitters)
        {
            if (orbit != this)
                Attract(orbit);
        }
    }

    void OnEnable()
    {

        if (Orbitters == null)
            Orbitters = new List<Orbit>();

        Orbitters.Add(this);
    }

    void OnDisable()
    {
        Orbitters.Remove(this);
    }

    void Attract(Orbit objToOrbit)
    {
        Rigidbody rbToOrbit = objToOrbit.rb;

        Vector3 direction = rb.position - rbToOrbit.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = G * (rb.mass * rbToOrbit.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToOrbit.AddForce(force);
    }
}
