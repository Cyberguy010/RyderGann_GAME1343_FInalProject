using UnityEngine;

public class SpinScript : MonoBehaviour
{
    public string message = "Hello Everyone";
    public Vector3 spinRate = Vector3.zero;
    // Units per Second

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Display start message variable, a member of the class
        Debug.Log(message);
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(spinRate * Time.deltaTime);
    }
}
