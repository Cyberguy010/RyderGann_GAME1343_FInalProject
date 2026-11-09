using UnityEngine;

public class ProjectileBase : MonoBehaviour
{

    public float damageAmount = 10;

    public float moveSpeed = 5f; // units per second

    public float lifeTime = 5f; // seconds

    public GameObject deathDecalPrefab; // prefab item

    public CombatController owner;

    Rigidbody rb;
   
    void Start()
    {
        Destroy(gameObject, lifeTime);

        rb = gameObject.GetComponent<Rigidbody>();
        rb.linearVelocity = gameObject.transform.forward * moveSpeed;
        // Don't need Time.deltaTime as that's handled by the physics system
    }

    private void OnTriggerEnter(Collider other)
    {
        // hit another projectile 
        ProjectileBase pb = other.gameObject.GetComponentInParent<ProjectileBase>();
        if(pb)
        {

            pb.RemoveFromWorld(false);
            this.RemoveFromWorld();
            return; 
        }

        // hit Player -- CombatController
        CombatController cc = other.gameObject.GetComponentInParent<CombatController>();
        if (cc)
        {
            cc.AddDeath();
            cc.Reset();
            owner.AddKill();
            this.RemoveFromWorld();
            return;
        }
        this.RemoveFromWorld();
    }

    public void RemoveFromWorld(bool DropDecale = true )
    {

        if (DropDecale)
        {
            Instantiate(deathDecalPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }

        Destroy(gameObject);
    }
}
