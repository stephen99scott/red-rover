using System.Threading;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float initial_speed = 10f;
    public Rigidbody rb;
    public float m1 = 1f;
    public float mcenter = 2f;
    public float r = 10f;
    public float G = 10f;
    public float rotationRate = 222.86f;
    public GameObject center;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 50 * initial_speed);
        if(rb.name == "Moon")
        {
            rb.AddForce(transform.up * 100);
        }
    }

    void FixedUpdate()
    {
        Vector3 center_position = center.transform.position;
        Vector3 pos = transform.position;
        Vector3 dir = (center_position - pos) / pos.magnitude;
        dir = dir / dir.magnitude;
        r = (pos - center_position).magnitude;
        Vector3 force_to_apply = dir * G * m1 * mcenter / (r * r);
        rb.AddForce(force_to_apply);
        rb.transform.RotateAround(rb.transform.position, rb.transform.up, rotationRate);
    }
}
