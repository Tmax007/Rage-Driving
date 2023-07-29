using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         
    public Vector3 offset = new Vector3(0f, 2f, -5f);  

    public float smoothSpeed = 0.125f;   

    private void LateUpdate()
    {
        
        // Calculate desired position of camera based on the target's position and offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera to desired position
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set camera's position to  smooth position
        transform.position = smoothPosition;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}