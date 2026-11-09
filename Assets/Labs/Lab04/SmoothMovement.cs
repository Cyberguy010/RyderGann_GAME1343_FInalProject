using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    public float rotationRate = 180.0f;
    // Input Variables

    bool north = false; // w  Z+

    bool south = false; // s  Z-

    bool east = false; // a   X+

    bool west = false; // d   X-

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        if (north)
        {
            MovePlayer(1);
        }
        if (south)
        {
            MovePlayer(-1);
        }

        // Is better, moving towards unified input gathering methods.
        float horizontal = 0;
        if (east) { horizontal = 1; }
        if (west) { horizontal = -1; }

        RotatePlayer(horizontal);


    }
    
    public void MovePlayer(float value)
    {
        Vector3 location = gameObject.transformHandle.position;

        location += (movementSpeed * Time.deltaTime * value) * gameObject.transform.forward;

        gameObject.transform.position = location;
    }

    public void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(Vector3.up * value * rotationRate *  Time.deltaTime);
    }

    public void GetInput()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null)
        {
            Debug.Log("No Keyboard");
            return;
        }

        north = kb.wKey.isPressed;
        south = kb.sKey.isPressed;
        west = kb.aKey.isPressed;
        east = kb.dKey.isPressed;

    }
}
    
