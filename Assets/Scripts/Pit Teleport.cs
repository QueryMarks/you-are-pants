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
        Rigidbody rb;
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
        else
        {
            //Destroy(other);
        }
        
    }
}
