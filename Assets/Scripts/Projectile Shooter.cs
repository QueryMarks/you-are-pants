using System;
using UnityEngine;

public class ProjectileShooter : ShooterAttack
{
    public float speed = 10f;
    public float lifetime = 4f;
    public int damage = 1;

    private Rigidbody rb;
    private object gameObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private T GetComponent<T>()
    {
        throw new NotImplementedException();
    }

    public void Launch(Vector3 direction)
    {
        rb.linearVelocity = direction.normalized * speed;
        Destroy(gameObject, lifetime);
    }

    private void Destroy(object gameObject, float lifetime)
    {
        throw new NotImplementedException();
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

    private void Destroy(object gameObject)
    {
        throw new NotImplementedException();
    }
}
