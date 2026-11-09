using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector3 moveDirectionRate = Vector3.zero;
    // Units Per Second

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get Value
        Vector3 location = gameObject.transform.position;

        // Calculate New Value
        location += moveDirectionRate * Time.deltaTime;

        // Set a New Value Back
        gameObject.transform.position = location;
        
    }
}
