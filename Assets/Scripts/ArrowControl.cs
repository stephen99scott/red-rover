using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left")){
        	transform.Rotate(Vector3.forward);
        }
        if(Input.GetKey("right")){
        	transform.Rotate(Vector3.back);
        }
    }
}
