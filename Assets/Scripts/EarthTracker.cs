using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTracker : MonoBehaviour
{
    GameObject earth;
    public float rotationRate = 0;
    private void Start()
    {
        earth = GameObject.Find("Earth");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = earth.transform.position;
        transform.Rotate(transform.up, rotationRate);
    }
}
