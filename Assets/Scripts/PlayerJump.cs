using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float maxJumpHeight = 10f;
    [SerializeField] float jumpPower = 10f;

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
        if(IsGrounded() == true)
        {
            //Allow jump
            Vector3 newVelocity = playerRigid.linearVelocity;

        
            if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                newVelocity.y = jumpPower;
            }
            
            playerRigid.linearVelocity = newVelocity;
        }
    }

    public bool IsGrounded()
    {
        Collider col = transform.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center,Vector3.down);
        float radius = col.bounds.extents.x - 0.05f;
    
        float fullDistance = col.bounds.extents.y + 0.05f;
        return Physics.SphereCast(ray,radius,fullDistance);
    }
}
