using UnityEngine;

public class PhysicsMover : MonoBehaviour
{
    public int inputNumber = 0;

    public float moveSpeed = 5;

    public float rotateRate = 120;

    InputData input;

    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        input = InputPoller.reference.GetInput(inputNumber);

        MovePlayer(input.leftStick.y);
        RotatePlayer(input.leftStick.x);
    }

    void MovePlayer(float value)
    {
        if (!rb)
        {
            Debug.LogError(gameObject.name + "has no rigid body, cannot move.");
            return; 
        }

        rb.linearVelocity = value * moveSpeed * gameObject.transform.forward;
    }

    void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(Time.deltaTime * value * rotateRate * Vector2.up);
    }
}
