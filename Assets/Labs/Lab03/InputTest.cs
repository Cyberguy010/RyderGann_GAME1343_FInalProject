using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public Vector2 mousePosition;
    public Vector2 scrollWheel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        Keyboard kb = Keyboard.current;
        Mouse mouse = Mouse.current;
        Gamepad gpad = Gamepad.current;

        if (((kb == null)) || (mouse == null))
        {
            Debug.LogWarning("No keyboard or Mouse Found");
            return; // end this function now early
        }

        if (kb.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Space Key!");
        }

        if (kb.wKey.wasPressedThisFrame)
        {
            Debug.Log("W");
        }

        if (kb.tabKey.isPressed)
        {
            Debug.Log("Tab");
        }

        if (mouse.leftButton.isPressed)
        {
            Debug.Log("Left Click!");
        }






    }
}