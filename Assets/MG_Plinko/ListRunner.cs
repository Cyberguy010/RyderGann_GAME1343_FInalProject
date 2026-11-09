using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ListRunner : MonoBehaviour
{
    public List<GameObject> pathList;

    public int pathListIndex = 0;

    public GameObject currentTarget;

    public float movementSpeed = 5;

    public float withinRangeofPoint = 0.75f;

    public Vector3 moveDirection = Vector3.zero;

    public bool hasDynamicDirection = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathListIndex = 0;
        currentTarget = pathList[pathListIndex];
        UpdateMoveDirection();

    }

    // Update is called once per frame
    void Update()
    {
        if (hasDynamicDirection)
        {
            UpdateMoveDirection();
        }

        Vector3 location = gameObject.transform.position;
        location += moveDirection * movementSpeed * Time.deltaTime;
        gameObject.transform.position = location;

        if (IsClosetoTarget())
        {
            NextTarget();
            UpdateMoveDirection();
        }
    }

    public float GetDistanceTo(GameObject other)
    {
        Vector3 distanceVector = other.transform.position - gameObject.transform.position;
        return distanceVector.magnitude;
    }

    public bool IsClosetoTarget()
    {
        /*
        if (GetDistanceTo(currentTarget) <= withingRangeofPoint)
        {
            return true;
        }
        return false;
        */

        // the line below is the same a the lines above this comment

        return (GetDistanceTo(currentTarget) <= withinRangeofPoint);
    }

    void NextTarget()
    {
        pathListIndex++;

        if (pathListIndex >= pathList.Count)
        {
            pathListIndex = 0;

        }
        currentTarget = pathList[pathListIndex];
    }
    void PreviousTarget()
    {
        pathListIndex--;

        pathListIndex = pathListIndex % pathList.Count;

        currentTarget = pathList[pathListIndex];
    }

    public void UpdateMoveDirection()
    {
        Vector3 directionVector = currentTarget.transform.position - gameObject.transform.position;
        moveDirection = directionVector.normalized;
        // line above is the same as the line below 
        // moveDirection = directionVector.Normalize();

        // Set Facing of the object 
        gameObject.transform.forward = directionVector;
    }
}