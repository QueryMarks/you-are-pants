using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] StateMachine stateMachine;
    public DMG_ALIGN healthAlign = DMG_ALIGN.PLAYERDMG;
    float health = 50;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TakeDamage (Damager damager)
    {
        if (stateMachine != null)
        {
            //state machine will ask the state to handle taking damage
            stateMachine.TakeDamage(damager);
        }
        else
        {
            LoseHealth(damager.damage);
        }
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
