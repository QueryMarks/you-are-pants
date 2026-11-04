using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveTemp : MonoBehaviour
{
    public float speed = 2f;
    private GameObject player = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectsWithTag("ThePlayer")[0];

            if(player == null)
            {
                Debug.LogError("Failed to find the player!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position,target,speed * Time.deltaTime);
    }
}
