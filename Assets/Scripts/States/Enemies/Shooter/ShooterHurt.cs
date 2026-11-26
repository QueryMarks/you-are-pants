using UnityEngine;

public class ShooterHurt : ShooterState
{

    // Use this for initialization
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Ow, I am hurt and in pain");
        enemy.enemyRigid.useGravity = true;
    }
    public override void FixedUpdate()
    {
        enemy.health.stunTimer -= 1;
        if (enemy.health.stunTimer <= 0)
        {
            stateMachine.ChangeState(new ShooterIdle());
        }

        
    }
    public override void Exit()
    {
        enemy.enemyRigid.useGravity = false;
    }

}