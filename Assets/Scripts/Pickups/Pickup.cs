using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("pickup collided");
        Player player = other.transform.parent.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Activate(player);
        }
    }

    public virtual void Activate(Player player)
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.fixedTime*4)*0.005f, 0);
    }
}
