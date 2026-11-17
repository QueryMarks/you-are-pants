using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // The prefab of the projectile to be shot
    public Transform shootPoint; // The point from which the projectile will be shot

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2) // Shoot a projectile every second
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
       
    }
}
