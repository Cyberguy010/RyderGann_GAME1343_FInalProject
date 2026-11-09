using UnityEngine;
using UnityEngine.InputSystem;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 5.0f;
    // Input Variables

    bool north = false; // I  Z+

    bool south = false; // K  Z-

    bool east = false; // J   X+

    bool west = false; // L   X-

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        Vector3 location = gameObject.transform.position;

        if (north)
        {
            location += (Vector3.forward * gridSize);
        }
        if (south)
        {
            location += (Vector3.back * gridSize);
        }
        if (west)
        {
            location += (Vector3.left * gridSize);
        }
        if (east)
        {
            location += (Vector3.right * gridSize);
        }

        gameObject.transform.position = location;
    }

    public void GetInput()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null)
        {
            Debug.Log("No Keyboard");
            return;
        }

        north = kb.iKey.wasPressedThisFrame;
        south = kb.kKey.wasPressedThisFrame;
        east = kb.lKey.wasPressedThisFrame;
        west = kb.jKey.wasPressedThisFrame;



    }
}