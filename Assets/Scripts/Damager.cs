using UnityEngine;

public enum DMG_ALIGN
    {
        PLAYERDMG,
        ENEMYDMG
    };

public class Damager : MonoBehaviour
{
    //Alignment is if the damage is for enemies or players
    
    [SerializeField] DMG_ALIGN damageAlign = DMG_ALIGN.PLAYERDMG;
    public float damage = 10;
    //how long to stun an enemy in seconds
    public float hitstun = 0.5f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        Health health = collider.GetComponent<Health>();
        if (health != null)
        {
            if (health.healthAlign != damageAlign)
            {
                health.TakeDamage(this);
            }
        }
    }
}
