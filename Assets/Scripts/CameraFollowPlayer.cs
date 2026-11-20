using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraZDistance = -10;
    [SerializeField] float minChaseDistance = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool test = true;
        
    void Awake()
    {
        if(player == null)
        {
            //Now tracks the player's body for camera reasons.
            player = GameObject.FindWithTag("ThePlayer");
        }
    }

    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+5f, cameraZDistance);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(player != null)
        {
            //move towards the player's position by either the minimum chase distance or, if the player is pretty far, 1/10th the distance to player
            //-ethelyn
            Vector3 newPos = Vector3.MoveTowards(
                transform.position, 
                player.transform.position, 
                Mathf.Max(
                    minChaseDistance, 
                    Vector3.Distance(
                        transform.position, 
                        player.transform.position)*0.1f
                        )
                );
            transform.position = new Vector3(newPos.x, newPos.y, cameraZDistance);
            
            //transform.position = new Vector3(player.transform.position.x, player.transform.position.y+5f, cameraZDistance);
    
            
        }
        else
        {
            Debug.LogWarning("Player is NULL!");
        }
        
    }
}
