using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform player;

    public float projectileSpeed = 10f;
    public float fireRate = 2f;
    public float range = 10f;

    public bool shootAt80Degrees = false;

    private float nextFireTime;

    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("ThePlayer").transform;

            if (player == null)
            {
                Debug.Log("Projectile Launcher failed to find ThePlayer gameobject!");
                return;
            }
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance<=range&&Time.time>=nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
        return;

        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            firePoint.rotation
        );
        SoundEffectManager.Play("ProjectileShoot");
        Damager damager = projectile.GetComponent<Damager>();
        if (damager != null)
        {
            damager.owner = gameObject;
            damager.damageAlign = DMG_ALIGN.ENEMYDMG;
        }
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 direction;

        if (shootAt80Degrees)
        {
            // 80 degrees from the X axis
            float angle = 80f * Mathf.Deg2Rad;
            direction = new Vector3(
                Mathf.Cos(angle),
                Mathf.Sin(angle),
                0f
            ).normalized;
        }
        else
        {
            direction = Vector3.left;
        }
        rb.linearVelocity = Vector3.left * projectileSpeed;
    }
}
