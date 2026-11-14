using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public Rigidbody projectilePrefab; // The prefab of the projectile to be shot   
    public Transform shootPoint; // The point from which the projectile will be shot

    public float shootforce = 10f; // The force with which the projectile will be shot  
    public float shootRate = 1f; // The rate at which the projectile will be shot (in seconds)

    private float nextShootTime = 0f; // The time at which the next projectile can be shot

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetButton("Fire1") && Time.time >= nextShootTime)
        {
            ShootProjectile();
            nextShootTime = Time.time + shootRate; // Update the time for the next shot
        }
    }

    void ShootProjectile()
    {

    }
}
