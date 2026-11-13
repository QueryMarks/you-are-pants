
using UnityEngine;

public class PitRespawn : MonoBehaviour
{
    public float respawnHeight = 0.5f;
    public float respawnOffset = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThePlayer"))
        {
            Vector3 respawnPosition = other.transform.position;

            // Move player left and set height
            respawnPosition.x -= respawnOffset;
            respawnPosition.y = respawnHeight;

            // Stop player movement
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
            }

            // Respawn player
            other.transform.position = respawnPosition;
        }
    }
}
