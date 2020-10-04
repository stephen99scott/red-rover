using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EarthCam : MonoBehaviour
{

    public GameObject planet;
    GameObject sun;
    GameObject earth;
    GameObject mars;
    Vector3 desiredPos;
    Vector3 lookVec;

    void Start()
    {
        sun = GameObject.Find("Sun");
        earth = GameObject.Find("Earth");
        mars = GameObject.Find("Mars");
    }

    void Update()
    {
        lookVec = earth.transform.position - mars.transform.position;
        lookVec.Normalize();
        desiredPos = earth.transform.position + 2f*lookVec;
        desiredPos.y += 0.5f;
        transform.position = desiredPos;
        transform.LookAt(mars.transform.position);
        
    }

}
