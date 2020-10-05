using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsHealth : MonoBehaviour
{
    public static float health;
    private float startTime;

    void Start()
    {
        health = 100f;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        if (Time.time - startTime > 0.5)
        {
            startTime = Time.time;
            health -= 0.2f;
        }
    }
}
