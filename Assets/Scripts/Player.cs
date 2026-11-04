using UnityEngine;

public class Player : MonoBehaviour
{
    //movement variables
    public float movePower = 2f;
    public float moveAccel = 1f;
    public float maxJumpHeight = 10f;
    public float jumpPower = 10f;
    
    public Rigidbody playerRigid;

    public StateMachine stateMachine;

    private GameObject myObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigid = GetComponentInChildren<Rigidbody>();

        if(playerRigid == null)
        {
            Debug.LogError("Failed to find the player's rigid body component!");
        }

        //stateMachine.StateInit(new PlayerIdle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        Debug.Log("PLAYER SCRIPT! i have died");
    }

    public bool IsGrounded()
    {
        Collider col = transform.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center,Vector3.down);
        float radius = col.bounds.extents.x - 0.05f;
    
        float fullDistance = col.bounds.extents.y + 0.05f;
        return Physics.SphereCast(ray,radius,fullDistance);
    }

    //default movement behavior, only run when called by the current state
    public void DefaultMove()
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

    public void JumpCheck()
    {
        if (IsGrounded() == true)
        {
            //Allow jump
            Vector3 newVelocity = playerRigid.linearVelocity;


            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                newVelocity.y = jumpPower;
            }

            playerRigid.linearVelocity = newVelocity;
        }
    }
}
