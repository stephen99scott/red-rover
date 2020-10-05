using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public GameObject center;
    void Update()
    {
        transform.LookAt(center.transform.position);
    }
}
