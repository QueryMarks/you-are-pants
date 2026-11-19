using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 4f;
    public int damage = 1;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction)
    {
        rb.linearVelocity = direction.normalized * speed;
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Projectile"))
            return;

        if (other.CompareTag("ThePlayer"))
        {
            Debug.Log($"Player hit for {damage} damage!");
        }

        Destroy(gameObject);
    }
}
