using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraZDistance = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool test = false;
        
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
        if(!test)
        {
            transform.position = new Vector3(10,10,-10);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, cameraZDistance);
        }
        
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Test");
            if(test == true)
            {
                test = false;
            }
            else
            {
                test = true;
            }
        }
    }

    void LateUpdate()
    {
        if(player != null)
        {
            //transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
            //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, cameraZDistance);
        }
        else
        {
            Debug.LogWarning("Player is NULL!");
        }
        
    }
}
