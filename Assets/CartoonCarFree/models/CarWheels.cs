using UnityEngine;

public class CarWheels : MonoBehaviour
{
    public WheelCollider[] wheelColliders;
    public Transform[] wheels;
    private Vector3 position;
    private Quaternion rotation;

    public float torque;
    public float friction;
    public float vehicleBreak;
    public float angle;

    private void Start()
    {
        // Remove vehicle vibration
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].ConfigureVehicleSubsteps(1, 12, 15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CreateWheels();
    }

    private void FixedUpdate()
    {
        wheelColliders[0].steerAngle = angle * Input.GetAxis("Horizontal");
        wheelColliders[1].steerAngle = angle * Input.GetAxis("Horizontal");

        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].motorTorque = Input.GetAxis("Vertical") * torque;
            wheelColliders[i].brakeTorque = Input.GetKey(KeyCode.Space) ?
                                                    vehicleBreak :
                                                    friction - Mathf.Abs(Input.GetAxis("Vertical") * friction);
        }
    }

    void CreateWheels()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].GetWorldPose(out position, out rotation);
            wheels[i].position = position;
            wheels[i].rotation = rotation;
        }
    }
}