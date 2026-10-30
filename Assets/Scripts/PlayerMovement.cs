using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] float movePower = 2f;
    [SerializeField] float moveAccel = 1f;
    
    private Rigidbody playerRigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         playerRigid = GetComponentInChildren<Rigidbody>();

        if(playerRigid == null)
        {
            Debug.LogError("Failed to find the player's rigid body component!");
        }
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 newVelocity = playerRigid.linearVelocity;

        
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Mathf.Abs(newVelocity.x + (Input.GetAxisRaw("Horizontal") * moveAccel)) >= movePower)
                {
                    newVelocity.x = Input.GetAxisRaw("Horizontal") * movePower;
                }
                else
                {
                    newVelocity.x += Input.GetAxisRaw("Horizontal") * moveAccel;
                }
            }
            
            playerRigid.linearVelocity = newVelocity;
    }
}
