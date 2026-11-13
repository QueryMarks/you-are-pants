using UnityEngine;


//This is Demetrius's work! I just downloaded it manually due to git conflicts we are working out later. -Ethelyn
public class SpawnTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 3;

    private bool hasSpawned = false;

    bool coolThing = true;

    public void Start()
    {
        //Debug.Log("Count: " + enemyCount);
        
        //Debug.Log("Gave away!");
    }

    public void Update()
    {
        if(coolThing == true)
        {
            LevelManager.giveEnemies(enemyCount);
            coolThing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThePlayer") && !hasSpawned)
        {
            Debug.Log("THE PLAYER HAS ENTERED THE BATTLEZONE");
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 offset = Random.insideUnitSphere * 2f;
                offset = new Vector3(offset.x, offset.y, 0);

                Instantiate(
                    enemyPrefab,
                    (Vector3)transform.position + offset,
                    Quaternion.identity
                );
            }

            hasSpawned = true;
        }
    }

    public int getEnemyCount()
    {
        return enemyCount;
    }

        
    
}