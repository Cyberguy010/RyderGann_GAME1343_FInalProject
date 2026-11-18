using UnityEngine;

public class BarrrelPrefab : MonoBehaviour
{
    public int scoreGiven = 100;
    public float lifetime = 80;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        PlayerController pc = collision.gameObject.GetComponentInParent<PlayerController>();
        if (pc)
        {
            Debug.Log("Hit player"); 
        }
    }
    
}
