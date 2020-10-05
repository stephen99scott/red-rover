using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{
    public float rotationRate;

    void Update()
    {
        transform.Rotate(transform.up, rotationRate);
    }
}
