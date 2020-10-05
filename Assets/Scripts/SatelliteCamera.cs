using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SatelliteCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera Satellite;
    private GameObject Rover;
    private Vector3 pos;
    void Start()
    {
        Rover = GameObject.Find("Rover");
        Satellite.transform.position = new Vector3(Rover.transform.position.x, -700, Rover.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Satellite.transform.position = new Vector3(Rover.transform.position.x, -700, Rover.transform.position.z);
    }
}
