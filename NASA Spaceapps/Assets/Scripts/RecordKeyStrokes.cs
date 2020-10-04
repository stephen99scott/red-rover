using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordKeyStrokes : MonoBehaviour
{
	float startTime;
	int record;
	public static Queue keyQ;
    public GameObject RecordingLight;
    public static string message;
    // Start is called before the first frame update
    void Start()
    {
        keyQ = new Queue();
        record = -1;
        RecordingLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        //record = 0;
        if(Input.GetKeyDown(KeyCode.Space)){ //hold space
        	startTime = Time.time;
        	record *= -1;
            //turn recording light on
            if (record == 1)
            {
                RecordingLight.SetActive(true);
            }
            else
            {
                RecordingLight.SetActive(false); ;
            }
            print("RECORDING STARTED");
        }

        if(record == 1)
        {

            //if (Input.GetKeyDown(KeyCode.LeftArrow)) keyQ.Enqueue('L');
            if (Input.GetKeyDown(KeyCode.LeftArrow)) message += "L";
            else if (Input.GetKeyDown(KeyCode.RightArrow)) message += "R";
            else if (Input.GetKeyDown(KeyCode.UpArrow)) message += "U";
            else if (Input.GetKeyDown(KeyCode.DownArrow)) message += "D";
            else message += "N";
    	}

    }

}

