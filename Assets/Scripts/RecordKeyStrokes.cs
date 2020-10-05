using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordKeyStrokes : MonoBehaviour
{
    int record;
    public GameObject RecordingLight;
    public static string message = "";
   
    void Start()
    {
        record = -1;
        RecordingLight.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){ //hold space
        	record *= -1;
            //turn recording light on
            if (record == 1)
            {
                RecordingLight.SetActive(true);
                print("RECORDING STARTED");
            }
            else
            {
                RecordingLight.SetActive(false);
                print("RECORDING STOPPED");
            }
        }

        if(record == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) message += "L";
            else if (Input.GetKeyDown(KeyCode.RightArrow)) message += "R";
            else if (Input.GetKeyDown(KeyCode.UpArrow)) message += "U";
            else if (Input.GetKeyDown(KeyCode.DownArrow)) message += "D";
            else message += "N";
    	}

    }

}

