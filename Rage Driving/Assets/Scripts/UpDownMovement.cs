using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float minHeight = 1f;        
    public float maxHeight = 5f;        
    public float moveSpeed = 1f;     
    public float waitTimeMin = 1f;      
    public float waitTimeMax = 5f;     

    private Vector3 startingPosition;  
    private Vector3 targetPosition;   

    private void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(UpAndDownMovement());
    }

    private IEnumerator UpAndDownMovement()
    {
        while (true)
        {
            // Generate a random target position within the specified height range
            float randomHeight = Random.Range(minHeight, maxHeight);
            targetPosition = new Vector3(startingPosition.x, startingPosition.y + randomHeight, startingPosition.z);

            // Move the object towards the target position
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
                yield return null;
            }

            // Wait for a random amount of time before changing direction
            float waitTime = Random.Range(waitTimeMin, waitTimeMax);
            yield return new WaitForSeconds(waitTime);
        }
    }
}

