using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] StateMachine stateMachine;
    public DMG_ALIGN healthAlign = DMG_ALIGN.PLAYERDMG;
    public float health = 50;
    public int stunTimer = 0;
    Player player;


    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        player = GetComponent<Player>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TakeDamage (Damager damager)
    {
        Debug.Log("TAKING DAMAGE!");
        stunTimer = damager.hitstun;
        if (stateMachine != null)
        {
            //state machine will ask the state to handle taking damage
            stateMachine.TakeDamage(damager);
        }
        else
        {
            Rigidbody rb = GetComponentInChildren<Rigidbody>();
            if (rb != null)
            {
                TakeKnockback(damager);   
            }
            if (!LoseHealth(damager.damage))
            {
                Invoke("BasicDie", 2f);
            }
        }

    }

    public void TakeKnockback(Damager damager)
    {
        Rigidbody rb = GetComponentInChildren<Rigidbody>();
        float myPosX = rb.position.x;
        float damagerPosX = damager.owner.transform.position.x;
        int knockbackRight = -1;
        if (myPosX >= damagerPosX)
        {
            knockbackRight = 1;
        }
        rb.linearVelocity = new Vector3(damager.knockback.x * knockbackRight, damager.knockback.y, damager.knockback.z);
    }
    void BasicDie()
    {
        Destroy(this.gameObject);
    }

    //returns true if the entity lives
    public bool LoseHealth(float amount)
    {
        health -= amount;

        
        if (health <= 0)
        {
            Debug.Log("Player, or enemy, should die here!");
            return false;
        }
        
        return true;
    }
    public void GainHealth(float amount)
    {
        health += amount;
    }
}
