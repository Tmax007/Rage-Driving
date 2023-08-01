using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSorroundingChecker : MonoBehaviour
{
    [Range(0f,10f)]
    public float raycastDistance = 5f;
    [Range(0f, 10f)]
    public float raycastOffset = 1f;

    private Vector3 distanceToRightRay;
    private Vector3 distanceToLeftRay;
    private Vector3 rayForwardDistance;

    void Start()
    {
        
    }

    public bool checkVehicleOnOtherLane()
    {
        Vector3 pos = transform.position;

        distanceToRightRay = transform.right * raycastOffset;
        distanceToLeftRay = -distanceToRightRay;
        rayForwardDistance = transform.forward * raycastDistance;

        Vector3 rightSideRayStart = distanceToRightRay - rayForwardDistance;
        Vector3 leftSideRayStart = distanceToLeftRay - rayForwardDistance;

        RaycastHit hit;

        if (Physics.Raycast(pos + rightSideRayStart, transform.forward, out hit, raycastDistance * 2))
        {
            return true;
        }
        if (Physics.Raycast(pos + leftSideRayStart, transform.forward, out hit, raycastDistance * 2))
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        distanceToRightRay = transform.right * raycastOffset;
        distanceToLeftRay = -distanceToRightRay;
        rayForwardDistance = transform.forward * raycastDistance;

        Vector3 pos = transform.position;
        Gizmos.color = Color.yellow;

        Vector3 rightSideRayStart = distanceToRightRay - rayForwardDistance;
        Vector3 rightSideRayEnd = distanceToRightRay + rayForwardDistance;
        Gizmos.DrawLine(pos + rightSideRayStart, pos + rightSideRayEnd);

        Vector3 leftSideRayStart = distanceToLeftRay - rayForwardDistance;
        Vector3 leftSideRayEnd = distanceToLeftRay + rayForwardDistance;
        Gizmos.DrawLine(pos + leftSideRayStart, pos + leftSideRayEnd);
    }
}