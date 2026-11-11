using UnityEngine;
using UnityEngine.InputSystem;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;


    // Update is called once per frame
    void Update()
    {
        Keyboard kb = Keyboard.current;
        if(kb == null)
        {
            return;
        }

        if(kb.eKey.wasPressedThisFrame)
        {
            Instantiate(barrelPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
