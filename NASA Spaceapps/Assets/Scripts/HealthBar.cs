using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    public Scrollbar healthbar;

    void Start()
    {
        health = 1f;
    }

    // Update is called once per frame
    void Update()
    {
      //  mars = FindObjectOfType<MarsHealth>();
    //    Debug.Log(MarsHealth.health);
        health = MarsHealth.health / 100f;
        healthbar.size = health;
    }
}
