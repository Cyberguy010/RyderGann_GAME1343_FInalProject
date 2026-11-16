using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float gravity = -9.8f;
    public int inputNumber = 1;
    public int playerScore = 0;
    public int playerLives = 3;
    InputData data;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        data = InputPoller.reference.GetInput(inputNumber);

        MovePlayer(data.leftStick.x);
        JumpPlayer(data.leftStick.y);
    }

    public void MovePlayer(float value)
    {
       
    }
    public void JumpPlayer(float value)
    {
        
    }
}
