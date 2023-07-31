using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarObstacle : MonoBehaviour
{
    public float speed = 10f;
    public float leftLaneSpeedMultiplyer = 0.75f;
    public float rightLaneSpeedMultiplyer = 1.25f;
    public float changeLaneSpeed = 5f;

    public int currentLaneNumber;

    Rigidbody rb;
    RoadPath roadPath;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        roadPath = GetComponentInParent<RoadPath>();
        CheckCurrentLane();
        AlignWithLane(roadPath.Lanes[currentLaneNumber].position.x);
        ChangeSpeedBasedOnLane(currentLaneNumber);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        //CheckCurrentLane();
    }

    private void Move()
    { 
        rb.velocity = new Vector3(0, 0, speed);
    }

    private void ChangeSpeedBasedOnLane(int laneNumber)
    {
        if(laneNumber == 0)
        {
            speed = speed * leftLaneSpeedMultiplyer;
        }
        else if(laneNumber == 2)
        {
            speed = speed * rightLaneSpeedMultiplyer;
        }
    }

    private void CutOffPlayer()
    {

    }

    private void CheckCurrentLane()
    {
        Vector3 currentLane = Vector3.zero;
        Vector3 LastLane = Vector3.zero;
        for (int i = 0; i < roadPath.Lanes.Length; i++)
        {
            currentLane = roadPath.Lanes[i].position;
            if(Vector3.Distance(new Vector3(transform.position.x,0,0), new Vector3(currentLane.x, 0, 0)) <= Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(LastLane.x, 0, 0)))
            {
                currentLaneNumber = i;
            }
            LastLane = currentLane;
        }
    }

    private void AlignWithLane(float xPos)
    {
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
    
}
