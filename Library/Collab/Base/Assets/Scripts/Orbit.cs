using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;
    GameObject sun;
    Vector3 sun_position;
    float initial_speed = 10f;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        GameObject sun = GameObject.Find("Sun");
        Vector3 sun_position = sun.transform.position;
        rb.AddForce(transform.forward * 500);
    }

    void FixedUpdate()
    {
        
        Vector3 pos = this.transform.position;
        Vector3 dir = sun_position - pos;
        rb.AddForce(dir * thrust);
    }
}
