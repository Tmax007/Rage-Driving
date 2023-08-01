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
    public float changeLaneInSeconds = 5f;
    private bool currentlyChangingLane = false;

    public int currentLaneNumber;

    Rigidbody rb;
    RoadPath roadPath;
    CarSorroundingChecker checkRayCast;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        roadPath = GetComponentInParent<RoadPath>();
        checkRayCast = GetComponent<CarSorroundingChecker>();
        GetCurrentLaneNumber();
        AlignPositionToLane(currentLaneNumber);
        ChangeSpeedBasedOnLane(currentLaneNumber);
        StartCoroutine(ChangeLaneTimer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if(currentlyChangingLane)
        {
            MoveToChangeLane(currentLaneNumber);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector3(0, 0, speed);
    }
    private void GetCurrentLaneNumber()
    {
        Vector3 currentLane = Vector3.zero;
        Vector3 LastLane = Vector3.zero;
        for (int i = 0; i < roadPath.Lanes.Length; i++)
        {
            currentLane = roadPath.Lanes[i].position;
            if(Mathf.Abs(transform.position.x - currentLane.x) <= Mathf.Abs(transform.position.x - LastLane.x))
            {
                currentLaneNumber = i;
            }
            LastLane = currentLane;
        }
    }

    private void MoveToChangeLane(int laneNum)
    {
        Vector3 xLane = new Vector3(roadPath.Lanes[laneNum].position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, xLane, Time.deltaTime * changeLaneSpeed);
        if(Mathf.Abs(transform.position.x - roadPath.Lanes[laneNum].position.x) < 0.01f)
        {
            currentlyChangingLane = false;
            currentLaneNumber = laneNum;
            ChangeSpeedBasedOnLane(laneNum);
        }
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
    private void AlignPositionToLane(int laneNum)
    {
        transform.position = new Vector3(roadPath.Lanes[laneNum].position.x, transform.position.y, transform.position.z);
    }

    private void CutOffPlayer()
    {

    }

    private IEnumerator ChangeLaneTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeLaneInSeconds);
            currentLaneNumber = (int)Random.Range(0, roadPath.Lanes.Length);
            if(checkRayCast.checkVehicleOnOtherLane() == false)
            {
                currentlyChangingLane = true;
            }
        }
    }
}
