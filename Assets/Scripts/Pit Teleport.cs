using UnityEngine;

public class PitTeleport : MonoBehaviour
{
    [SerializeField] Vector3 returnPosition =  Vector3.zero;    //I am treating Vector3.zero as null, hence the debug error log! - ME
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Enemy es;
        Rigidbody rb;
        PuzzleButtons pb;

        //Debug.Log("AFSHASDJANSF");

        if(other.tag == "ThePlayer")
        {
            if(returnPosition == Vector3.zero)
            {
                Debug.LogError("Pit returns the player to 0,0,0\nMake sure this is intended behavior!");
            }
            
            other.transform.parent.transform.position = returnPosition;
            
            rb = other.GetComponent<Rigidbody>();

            if(rb)
            {
               rb.linearVelocity = Vector3.zero; 
            }
        }
        else if(other.tag == "Puzzle Block")
        {
            Debug.Log("Puzzle Block is going out of bounds!");
            pb = other.GetComponent<PuzzleButtons>();

            if(pb != null)
            {
                pb.ResetPosition();
            }
            
        }
        else
        {
            es = other.GetComponentInParent<Enemy>();
            if(es != null)
            {
                //Debug.LogError("An enemy has fallen in to the pit!");
                es.Die();

            }
            else
            {
                Debug.Log("Something that is neither a player nor an enemy has fallen out of bounds!\nThey have been destroyed!");
                Destroy(other.gameObject);
            }
            //Destroy(other);
        }
        
    }
}
