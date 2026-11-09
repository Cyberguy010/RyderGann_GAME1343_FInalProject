using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifetime = 1.5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
