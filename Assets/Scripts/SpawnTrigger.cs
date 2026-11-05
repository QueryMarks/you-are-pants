using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 3;

    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasSpawned)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector2 offset = Random.insideUnitCircle * 2f;

                Instantiate(
                    enemyPrefab,
                    (Vector2)transform.position + offset,
                    Quaternion.identity
                );
            }

            hasSpawned = true;
        }
    }
}