using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
 
    public float maxSpeed = 100f;           
    public float rotationSpeed = 100f;
    public float acceleration = 10f;                       
    public float deceleration = 10f;
    public float handbrakeDeceleration = 20f;

    public AudioClip honkSound;

    private float horizontalInput;     
    private float verticalInput;
    private float currentSpeed;

    public float deathZone = -10f;
    public Transform endZone;
    public Vector3 startingPosition;

    private AudioSource audioSource;

    private bool isHandbrakeActive = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Read input axes for car
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Check for honk input
        if (Input.GetKeyDown(KeyCode.H))
        {
            Honk();
        }

        // Check if the car falls below the death zone
        if (transform.position.y < deathZone)
        {
            RespawnCar();
        }

        // Check if the car reaches the end of the road
        if (Vector3.Distance(transform.position, endZone.position) <5f)
        {
            RespawnCar();
        }
        
        // Check for handbrake input
        if (Input.GetKey(KeyCode.Space))
        {
            isHandbrakeActive = true;
        }
        else
        {
            isHandbrakeActive = false;
        }
    }

    private void FixedUpdate()
    {
        MoveCar();
        RotateCar();
    }

    private void MoveCar()
    {
        // Car's forward movement
        Vector3 movement = transform.forward * verticalInput * acceleration * Time.fixedDeltaTime;

        if (isHandbrakeActive)
        {
            // Apply handbrake deceleration
            float handbrakeDecelerationAmount = handbrakeDeceleration * Time.fixedDeltaTime;
            float speedSign = Mathf.Sign(currentSpeed);
            currentSpeed = Mathf.Clamp(Mathf.Abs(currentSpeed) - handbrakeDecelerationAmount, 0f, maxSpeed) * speedSign;
            movement = transform.forward * currentSpeed * Time.fixedDeltaTime;
        }

        // Deceleration when not accelerating
        else if (Mathf.Approximately(verticalInput, 0f))
        {
            float decelerationAmount = deceleration * Time.fixedDeltaTime;
            float speedSign = Mathf.Sign(currentSpeed);
            currentSpeed = Mathf.Clamp(Mathf.Abs(currentSpeed) - decelerationAmount, 0f, maxSpeed) * speedSign;
            movement = transform.forward * currentSpeed * Time.fixedDeltaTime;
        }

        else
        {
            // Accelerate the car and cap the speed at the maxSpeed
            currentSpeed = Mathf.Clamp(currentSpeed + (verticalInput * acceleration * Time.fixedDeltaTime), 0f, maxSpeed);
            movement = transform.forward * currentSpeed * Time.fixedDeltaTime;
        }

        // Movement to car's Rigidbody
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movement);
    }

    private void RotateCar()
    {
        // Car's rotation based on horizontal input
        float rotation = horizontalInput * rotationSpeed * Time.fixedDeltaTime;

        // Rotation amount
        Quaternion rotationQuaternion = Quaternion.Euler(0f, rotation, 0f);

        // Rotation to car's Rigidbody
        GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * rotationQuaternion);
    }

    private void Honk()
    {
        // Play the honk sound
        if (honkSound && audioSource)
        {
            audioSource.PlayOneShot(honkSound);
        }
    }

    private void RespawnCar()
    {
        // Reset the car's position and rotation to the starting position
        transform.position = startingPosition;
        transform.rotation = Quaternion.identity;

        // Reset the current speed to zero
        currentSpeed = 25f;
    }
}


