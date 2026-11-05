using UnityEngine;

public enum DMG_ALIGN
    {
        PLAYERDMG,
        ENEMYDMG
    };

public class Damager : MonoBehaviour
{
    public GameObject owner;
    //Alignment is if the damage is for enemies or players
    
    [SerializeField] DMG_ALIGN damageAlign = DMG_ALIGN.PLAYERDMG;
    public float damage = 10;
    //how long to stun an enemy in seconds
    public int hitstun = 30;

    public Vector3 knockback;

    Player player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (damageAlign == DMG_ALIGN.PLAYERDMG)
        {
            player = owner.GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("entering");
        Health health = collider.GetComponentInParent<Health>();
        if (health != null)
        {
            Debug.Log("found health");
            if (health.healthAlign != damageAlign)
            {
                health.TakeDamage(this);
                if (damageAlign == DMG_ALIGN.PLAYERDMG)
                {
                    player.UpdateCombo(player.combo + 1);
                }
            }
        }
    }
}
