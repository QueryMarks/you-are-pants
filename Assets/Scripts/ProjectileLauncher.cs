
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float projectileSpeed = 10f;
    public float fireRate = 2f;

    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            firePoint.rotation
        );
        Damager damager = projectile.GetComponent<Damager>();
        if (damager != null)
        {
            damager.owner = gameObject;
        }
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        rb.linearVelocity = Vector3.left * projectileSpeed;
    }
}
