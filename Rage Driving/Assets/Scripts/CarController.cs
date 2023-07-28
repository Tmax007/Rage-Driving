using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
 
    public float speed = 10f;           
    public float rotationSpeed = 100f;

    public AudioClip honkSound;

    private float horizontalInput;     
    private float verticalInput;

    public float deathZone = -10f; 
    public Vector3 startingPosition;

    private AudioSource audioSource;

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

        // Check if the car falls below the Y-coordinate threshold
        if (transform.position.y < deathZone)
        {
            RespawnCar();
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
        Vector3 movement = transform.forward * verticalInput * speed * Time.fixedDeltaTime;

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
        
    }
}


