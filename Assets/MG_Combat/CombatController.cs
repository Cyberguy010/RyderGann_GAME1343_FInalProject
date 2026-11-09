using UnityEngine;

public class CombatController : MonoBehaviour
{
    public int inputNumber = 0;
    public int playerNumber = 1;

    public float moveSpeed = 5;

    public float rotateRate = 120;

    public GameObject deathDecalPrefab;
    public GameObject RayCastHitPrefab;

    public GameObject projectilePrefab;

    public Transform FiringPoint;
    public LaserControl laserControl;

    public float RayDistance = 50f;
    public Color DebugRayColor = Color.red;

    // Projectiles Weapons
    public bool Fire1IsEnabled = true;
    // RayCast Weapons
    public bool Fire2IsEnabled = true;

    public AudioClip clip_BAP;
    public AudioClip clip_PEW;

    public float pitchMin = .7f;
    public float pitchMax = 1.3f;

    public int kills = 0;
    public int deaths = 0;
    public float KDratio = 0;



    InputData input;

    Rigidbody rb;

    AudioSource source;

    Vector3 startingLocation;
    Quaternion startingRotation;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        source = gameObject.AddComponent<AudioSource>();

        startingLocation = gameObject.transform.position;
        startingRotation = gameObject.transform.rotation;
    }

    
    public void Update()
    {
        DrawDebugLine();

        input = InputPoller.reference.GetInput(inputNumber);



        MovePlayer(input.leftStick.y);
        RotatePlayer(input.leftStick.x);

        if (input.buttonNorth && Fire1IsEnabled)
        {
                  Fire1();
        }
        if (input.buttonEast && Fire2IsEnabled)
        {
                Fire2();
        }
    }

    public void DrawDebugLine()
    {
        Vector3 originPoint = FiringPoint.position;
        Vector3 destinationPoint = (FiringPoint.transform.forward * RayDistance);

        Debug.DrawRay(originPoint, destinationPoint, DebugRayColor);
    }

    


    void MovePlayer(float value)
    {
        if (!rb)
        {
            Debug.LogError(gameObject.name + "has no rigid body, cannot move.");
            return;
        }

        rb.linearVelocity = value * moveSpeed * gameObject.transform.forward;
    }

    void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(Time.deltaTime * value * rotateRate * Vector2.up);
    }

    public void Fire1()
    {
        // Projectile Fire
        //Debug.Log("Fire1");
        //
        SetSoundRandomPitch();
        source.PlayOneShot(clip_BAP);
        FireProjectile();
    }

    public void FireProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
        ProjectileBase pb = newProjectile.GetComponent<ProjectileBase>();
        pb.owner = this;
    }

    public void Fire2()
    {
        // Raycast Fire
        // Debug.Log("Fire2");
        SetSoundRandomPitch();
        source.PlayOneShot(clip_PEW);
        PerformRayCast();
    }

    public void PerformRayCast()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(FiringPoint.position, FiringPoint.forward, out hit, RayDistance);

        if (hasHit)
        {
            Debug.Log("Raycast hit on " + hit.collider.gameObject.name);

            // Spawn prefab for hit
            Instantiate(RayCastHitPrefab, hit.point, Quaternion.identity);

            laserControl.FireLaser(hit.distance);

            CombatController cc = hit.collider.gameObject.GetComponentInParent<CombatController>();
            if (cc)
            {
                Debug.Log("Raycast hit on player " + cc.gameObject.name);
                cc.AddDeath();
                cc.AddKill();
                this.AddKill();
            }

            ProjectileBase pb = hit.collider.gameObject.GetComponentInParent<ProjectileBase>();
            if(pb)
            {
                // false = dont spawn projectile's prefab
                pb.RemoveFromWorld(false);
            }
        }
    }

   

    public void SetSoundRandomPitch()
    {
        source.pitch = Random.Range(pitchMin, pitchMax);
    }

    public void Reset()
    {
        Instantiate(deathDecalPrefab, gameObject.transform.position, gameObject.transform.rotation);

        gameObject.transform.position = startingLocation;
        gameObject.transform.rotation = startingRotation;
        rb.angularVelocity = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
    }

    public void AddKill()
    {
        kills++;
        CalculateKDRatio();
        CombatManager.instance.AddScore(playerNumber);
    }
    public void AddDeath()
    {
        deaths++;
        CalculateKDRatio();
    }
    public void CalculateKDRatio()
    {
        if (deaths == 0)
        {
            KDratio = kills;
            return;
        }
        KDratio = (float)kills / (float)deaths;
    }

}


