using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RotateCam : MonoBehaviour
{

    public Transform cam;
    public GameObject planet;
    GameObject sun;

    void Start()
    {
        sun = GameObject.Find("Sun");
    }

    // Update is called once per frame
    void Update()
    {
        // Find direction to face
        //Vector3 sun_position = sun.transform.position;
        //Vector3 pos = planet.transform.position;
        Vector3 dir = -transform.position;
        // Rotate camera
        Quaternion rotation = Quaternion.LookRotation(dir);
        cam.rotation = rotation;
        transform.position = new Vector3(1.1f*planet.transform.position.x, 1.1f*planet.transform.position.y + 0.5f, 1.1f*planet.transform.position.z);

    }
}
