using UnityEngine;

public class Bobber : MonoBehaviour
{
    public float bobbHeight = 5;
    public float bobbSpeed = 1;

    Vector3 StartingLocation;
    float ceiling = 0;
    float floor = 0;

    float direction = 1; // 1 moves up, -1 goes down
    // Bool example
    // bool isMoveingUp = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartingLocation = gameObject.transform.position;
        floor = StartingLocation.y;
        ceiling = StartingLocation.y + bobbHeight;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 location = gameObject.transform.position;

        location.y += direction * bobbSpeed * Time.deltaTime;

        if (location.y >= ceiling)
        {
            direction = -1; // Move back down
            // if set bool to false if using it
            location.y = ceiling;
        }
        if (location.y <= floor)
        {
            direction = 1; // Move back up
            // if set bool to true is using it
            location.y = floor;
        }

        gameObject.transform.position = location;

    }
}
