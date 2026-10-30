using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraZDistance = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("ThePlayer");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if(player != null)
        {
            transform.position = new Vector3(player.transform.position.x,player.transform.position.y,cameraZDistance);
        }
        
    }
}
