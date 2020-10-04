using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGen : MonoBehaviour
{

    public GameObject Signal;
    public Camera cam;
    public GameObject Earth;
    public GameObject Mars;
    Vector3 dir;
    Vector3 angleVel;
    public float vel = 10.0f ;
    float cooldown;

    void Start()
    {

    }

    public void Update()
    {
        if(Time.time > cooldown)
        {
            if(Input.GetButton("Fire1"))
            {
                GameObject resource = (GameObject) Instantiate(Signal, Earth.transform.position, 
                    Quaternion.identity);
                ResourcePath.inputInfo = RecordKeyStrokes.message;

                dir = (- Earth.transform.position + Mars.transform.position);
                dir.Normalize();
                resource.GetComponent<Rigidbody>().velocity = dir*vel;
                cooldown = Time.time + 0.5f;
            }
        }
    }   
}