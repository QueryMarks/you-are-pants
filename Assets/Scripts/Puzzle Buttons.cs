using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
    [SerializeField] Vector2 rightSpot;

    [SerializeField] Vector3 respawnSpot = new Vector3(0,0,-1); //z = -1 means the button has no respawn spot! - Used because I cannot set Vector2 t NULL!
    
    bool state = false;     //Whether or not this puzzle box is standing in the correct state!

    Collider col;

    Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //col = gameObject.GetComponent<Collider>();

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
                rb.linearVelocity = new Vector3(0,0,0);
                transform.position = respawnSpot;
            }


        }
    }
}
