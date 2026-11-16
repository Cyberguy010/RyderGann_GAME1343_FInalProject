using UnityEngine;

public class BarrrelPrefab : MonoBehaviour
{
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
}
