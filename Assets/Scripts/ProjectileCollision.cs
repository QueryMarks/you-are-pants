
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private Damager damager;
    private bool hasHit = false;

    void Start()
    {
        damager = GetComponent<Damager>();
    }

    void OnTriggerEnter(Collider other)
    {
        CheckHit(other, false);
    }

    void OnCollisionEnter(Collision collision)
    {
        CheckHit(collision.collider, true);
    }

    void CheckHit(Collider other, bool destroyOnContact)
    {
        if (hasHit)
            return;

        //Debug.Log("Projectile contacted: " + other.name);

        Health health = other.GetComponentInParent<Health>();

        if (health != null)
        {
            if (health.healthAlign == DMG_ALIGN.PLAYERDMG)
            {
                hasHit = true;

                //Debug.Log("PLAYER HIT!");

                health.TakeDamage(damager);

                Destroy(gameObject);
            }
        }
        else if (destroyOnContact)
        {
            hasHit = true;
            Destroy(gameObject);
        }
    }
}
