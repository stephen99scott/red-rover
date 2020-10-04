using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePath : MonoBehaviour
{
    // Start is called before the first frame update
    public float vel = 10.0f;
    Vector3 dir;
    GameObject Mars;
    GameObject Sun;
    public static string inputInfo = "";
    
    void Start()
    {
        Sun = GameObject.Find("Sun");
        Mars = GameObject.Find("Mars");
    }

    // Update is called once per frame
    void Update()
    {
    	dir = (- transform.position + Mars.transform.position);
        dir.Normalize();
      	transform.GetComponent<Rigidbody>().velocity = dir*vel;
        transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(3,7),Random.Range(3,7),Random.Range(3,7));
        
        if(Vector3.Distance(Mars.transform.position, transform.position) < 1.5) {
            //SUCCESSFUL TRANSMISSION TRIGGER HERE
            print("MESSAGE SUCCESS, MESSAGE IS: " + inputInfo);
            RoverController temp = GameObject.Find("Rover").GetComponent<RoverController>();
            temp.Commands(inputInfo);
            Destroy(gameObject);
        }
        if(Vector3.Distance(Sun.transform.position, transform.position) < 6) {
            //OH NO CRASH INTO SUN BRRRR NO COMMAND
            Destroy(gameObject);
        }

    }

}
