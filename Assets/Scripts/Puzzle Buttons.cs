using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
    [SerializeField] Vector2 rightSpot;

    [SerializeField] Vector3 respawnSpot = new Vector3(0,0,-1); //z = -1 means the button has no respawn spot! - Used because I cannot set Vector2 t NULL!

    [SerializeField] float maxVelocity = 3f;
    [SerializeField] float slowDownVelocity = 0.6f;
    [SerializeField] float playerSpeedUpVelocity = 0.3f;
    
    Collider col;
    bool state = false;     //Whether or not this puzzle box is standing in the correct state!

    Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = gameObject.GetComponent<Collider>();

        if(col == null)
        {
            Debug.LogError("Failed to get Puzzle Cube's collider!");
        }

        rb = GetComponent<Rigidbody>();

        if(rb == null)
        {
            Debug.LogError("Failed to get Puzzle Button's Rigid Body!");
        }
    }

    // Update is called once per frame
    void Update()
    {

        //If the box I am assigned to is ontop of me
        //Change my state to true! - meaning the the thing is complete!

        //Debug.Log(transform.position.ToString() + "\n" + rightSpot.ToString());

        if(transform.position.x >= rightSpot.x && transform.position.x <= rightSpot.x + 1)
        {
            //I am within the right spot on the X!
            if(transform.position.y >= rightSpot.y && transform.position.y <= rightSpot.y + 1)
            {
                //I am within the right spot on both X and Y!
                state = true;
                //Debug.Log("I am in the right spot!");
            }
            else
            {
                state = false;
            }

        }
        else
        {
            state = false;
        }
    }

    public void FixedUpdate()
    {
        float newX;

        if(rb.linearVelocity.x >= maxVelocity)
        {
            //Debug.Log("Slowing on the right!");
            newX = rb.linearVelocity.x - slowDownVelocity;
            rb.linearVelocity = new Vector3(newX,rb.linearVelocity.y,rb.linearVelocity.z);
        
        }
        else if(rb.linearVelocity.x  <= -1 * maxVelocity)
        {
            //Debug.Log("Slowing on the left!");
            newX = rb.linearVelocity.x + slowDownVelocity;
            rb.linearVelocity = new Vector3(newX,rb.linearVelocity.y,rb.linearVelocity.z);
        }
    }

    public bool GetButtonState()
    {
        return state;
    }

    public void OnCollisionEnter(Collision collision)
    {
       
        //Debug.Log("TOUCHING!");

        if(collision.gameObject.tag.Equals("Wall"))
        {
            //Debug.Log("Respawn: " + respawnSpot.z);
            if(respawnSpot.z == -1)
            {
                if(transform.position.x > collision.transform.position.x)
                {
                    transform.position = new Vector3(transform.position.x + 1,transform.position.y ,0);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x - 1,transform.position.y  ,0);
                }
            }
            else
            {
                //Debug.Log("ASDASD");
                rb.linearVelocity = Vector3.zero;
                transform.position = respawnSpot;
            }


        }
        else 
        {

        }
    }

    public void OnCollisionStay(Collision collision)
    {
         float newX;

        if(collision.gameObject.tag.Equals("ThePlayer"))
        {
            //Do stuff here to check where the player is and apply a speed up based on the edge of the box

            if(collision.transform.position.x >= col.bounds.center.x)
            {
                //Debug.Log("Speeding up right!");
                newX = rb.linearVelocity.x + playerSpeedUpVelocity;
                rb.linearVelocity = new Vector3(newX,rb.linearVelocity.y,rb.linearVelocity.z);
            }
            else
            {
                //Debug.Log("Speedin up left!");
                newX = rb.linearVelocity.x - playerSpeedUpVelocity;
                rb.linearVelocity = new Vector3(newX,rb.linearVelocity.y,rb.linearVelocity.z);
            }
        }
    }
}
