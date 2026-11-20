using UnityEngine;

public class Projectile : MonoBehaviour
{
        public float speed = 10f; // Speed of the projectile
        public float lifetime = 5f; // Lifetime of the projectile in seconds

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy the projectile after its lifetime expires
    }

    private void OnCollisionEnter(Collision collision)
    {
       Destroy(gameObject); // Destroy the projectile on collision
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
