using UnityEngine;
using UnityEngine.InputSystem;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;
    public float spawnInterval = 3.0f;
    public bool spawnOnStart = true;


    // Update is called once per frame
    void Update()
    {
        Keyboard kb = Keyboard.current;
        if(kb == null)
        {
            return;
        }

        if(kb.spaceKey.wasPressedThisFrame)
        {
            Instantiate(barrelPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
