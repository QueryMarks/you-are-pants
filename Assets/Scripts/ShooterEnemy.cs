using UnityEngine;

public class ShooterEnemy : Enemy
{
    public float chaseDistance = 20;
    public float attackDistance = 10;
    public float chaseSpeed;
    public float attackSpeed;

    public GameObject hitbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        stateMachine.StateInit(new ShooterIdle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
