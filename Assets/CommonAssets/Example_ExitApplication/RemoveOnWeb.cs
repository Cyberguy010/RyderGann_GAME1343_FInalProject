using UnityEngine;

public class RemoveOnWeb : MonoBehaviour
{
   
    void Start()
    {
#if UNITY_WEBGL
        gameObject.SetActive(false);
#endif
    }

}
