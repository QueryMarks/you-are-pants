using UnityEngine;

public class RusherEnemy : Enemy
{
    public float chaseDistance = 5;
    public float attackDistance = 10;
    public float chaseSpeed;
    public float attackSpeed;

    public GameObject hitbox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        base.Start();
        stateMachine.StateInit(new RusherIdle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
