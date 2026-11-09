using UnityEngine;
using UnityEngine.Rendering;

public class PlinkoSlot : MonoBehaviour
{

    public int scoreGiven = 100;
    public float removeDelay = 2.5f;

    public GameObject pointsEmote;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        mr.enabled = false;
    }

    private void OnTriggerEnter(Collider Other)
    {
        PlinkoDisk pd = Other.gameObject.GetComponentInParent<PlinkoDisk>();
        if(pd)
        {
            Debug.Log("Earned " + scoreGiven + " points");
            
            Destroy(pd.gameObject, removeDelay); 

            PlinkoManager.instance.AddScore(scoreGiven);

            Instantiate(pointsEmote, pd.gameObject.transform.position, Quaternion.identity);
        }
    }
}
