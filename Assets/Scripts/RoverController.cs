using System;
using UnityEngine;

public class RoverController : MonoBehaviour
{

    string localString;
    bool processCmd;
    int index;

    public enum WheelType
    {
        FrontLeft, FrontRight, BackLeft, BackRight, MidLeft, MidRight
    }

    [Serializable]
    class Wheel
    {
        public WheelCollider collider;
        public GameObject mesh;
        public WheelType wheelType;
    }

    [SerializeField] private Wheel[] wheels = new Wheel[6];
    [SerializeField] public float maxTorque = 2000f, maxBrakeTorque = 2000f, maxSteerAngle = 30f;
    [SerializeField] public float downForce = 300f;
    [SerializeField] public float topSpeed = 10;
    [SerializeField] public Transform centerOfMass;

    private float steering = 0f;
    private char prev_el = 'N';
    public bool Accelerating = false;
    public bool Deccelerating = false;

    private Rigidbody _rgbd;

    private void ShowWheel(Wheel wheel)
    {
        if (wheel.mesh == null || wheel.collider == null)
            return;

        Vector3 position;
        Quaternion rotation;
        wheel.collider.GetWorldPose(out position, out rotation);

        wheel.mesh.transform.position = position;
        wheel.mesh.transform.rotation = rotation;
    }


    public void Start()
    {
        _rgbd = GetComponent<Rigidbody>();
        if (centerOfMass != null && _rgbd != null)
            _rgbd.centerOfMass = centerOfMass.localPosition;
        for (int i = 0; i < wheels.Length; ++i)
            ShowWheel(wheels[i]);
    }

    private void Move(float motorInput)
    {

        motorInput = Mathf.Clamp(motorInput, -1f, 1f);
        if (motorInput > 0f)
        {
            Accelerating = true;
            Deccelerating = false;
        }
        else if (motorInput < 0f)
        {
            Accelerating = false;
            Deccelerating = true;
        }

        for (int i = 0; i < wheels.Length; ++i)
        {
            if (wheels[i].collider == null)
            {
                break;
            }
            if (wheels[i].wheelType == WheelType.FrontLeft || wheels[i].wheelType == WheelType.FrontRight)
            {
                wheels[i].collider.steerAngle = steering * maxSteerAngle; ;
            }

            wheels[i].collider.brakeTorque = 0f;
            if (Accelerating)
            {
                wheels[i].collider.motorTorque = motorInput * maxTorque / 4f;
            }
            else if (Deccelerating)
            {
                wheels[i].collider.motorTorque = motorInput * maxBrakeTorque / 4f;
            }

            if (wheels[i].mesh != null)
            {
                ShowWheel(wheels[i]);
            }
        }
    }


    private void ManageSpeed()
    {
        float speed = _rgbd.velocity.magnitude;
        speed *= 2.23693629f;
        if (speed > topSpeed)
        {
            _rgbd.velocity = topSpeed / 2.23693629f * _rgbd.velocity.normalized;
        }
    }
    void Update()
    {
        ManageSpeed();
        for (int i = 0; i < wheels.Length; ++i)
            ShowWheel(wheels[i]);
        _rgbd.AddForce(-transform.up * downForce);
        if (processCmd){
            char element = localString[index];
            if (element != 'N')
            {
                print("PROCCESSING " + element + " Index: " + index);
            }
            
            prev_el = ProcessCommand(element, prev_el);
            index++;
            if (index >= localString.Length)
            {
                processCmd = false;
                index = 0;
            }
        }
    }

    public char ProcessCommand(char element, char prevInput)
    {       
        float motor = 0f;

        if (element.Equals('N'))
        {
            element = prevInput;
        }
        if (element.Equals('U'))
        {
            motor += 1;
            prevInput = 'U';
        }
        if (element.Equals('D'))
        {
            motor += -1;
            prevInput = 'D';
        }

        if (element.Equals('L') && steering > -0.92)
        {
            steering += -0.08f;
            motor += 1;
            prevInput = 'L';
        }
        else if (element.Equals('R') && steering < 0.92)
        {
            steering += 0.08f;
            motor += 1;
            prevInput = 'R';
        }
        else if (!(element.Equals('R') || element.Equals('L')))
        {
            float cur_speed = _rgbd.velocity.magnitude * 2.23693629f;
            float speed_multiplier = Mathf.Clamp(cur_speed / 5f, 0f, 1f);

            if (steering > 0.08f * speed_multiplier)
            {
                steering += -0.08f * speed_multiplier;
            }
            if (steering < -0.08f * speed_multiplier)
            {
                steering += 0.08f * speed_multiplier;
            }

            if (-0.08f <= steering && steering <= 0.08f)
            {
                steering = 0;
            }
        }
        Move(motor);
        return prevInput;
    }

    public void Commands(string inputString)
    {
        localString = inputString;
        print("Rover trying: " + inputString);
        processCmd = true;
        index = 0;
    }

}
