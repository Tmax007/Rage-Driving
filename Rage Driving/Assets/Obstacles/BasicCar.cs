using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCar : MonoBehaviour
{
    //private Rigidbody rigidbody;

    [SerializeField] WheelCollider frontRightWheels;
    [SerializeField] WheelCollider frontLeftWheels;
    [SerializeField] WheelCollider backRightWheels;
    [SerializeField] WheelCollider backLeftWheels;

    [Range(5,200)]
    public float maxSpeed = 50f;
    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    public void Start()
    {
        //rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveCar();
        turnCar();
        breakInput();

        //turn the car
        frontRightWheels.steerAngle = currentTurnAngle;
        frontLeftWheels.steerAngle = currentTurnAngle;

        //apply the acceleration value to the front wheels
        frontLeftWheels.motorTorque = currentAcceleration;
        frontRightWheels.motorTorque = currentAcceleration;

        //apply breaking force to all wheels
        frontRightWheels.brakeTorque = currentBreakingForce;
        frontLeftWheels.brakeTorque = currentBreakingForce;
        backRightWheels.brakeTorque = currentBreakingForce;
        backLeftWheels.brakeTorque = currentBreakingForce;

        //rigidbody.velocity = Mathf.Clamp(rigidbody.velocity.magnitude, -maxSpeed, maxSpeed);
    }

    private void moveCar()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

    }

    private void turnCar()
    {
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

    }

    private void breakInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingForce;
        }
        else
        {
            currentBreakingForce = 0f;
        }

    }
} 
