using UnityEngine;

public class PitTeleport : MonoBehaviour
{
    [SerializeField] Vector3 returnPosition = new Vector3(0,0,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OggerEnter(Collider other)
    {
        if(other.tag == "The Player")
        {
            other.transform.position = returnPosition;
        }
        else
        {
            Destroy(other);
        }
        
    }
}
