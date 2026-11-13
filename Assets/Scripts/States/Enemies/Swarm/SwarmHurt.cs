using UnityEngine;

public class SwarmHurt : SwarmState
{

    // Use this for initialization
    public override void Enter()
    {
        base.Enter();
        Debug.Log("i am swarm and i am so hurt and in pain");
        enemy.enemyRigid.useGravity = true;
    }
    public override void FixedUpdate()
    {
        enemy.health.stunTimer -= 1;
        if (enemy.health.stunTimer <= 0)
        {
            stateMachine.ChangeState(new SwarmIdle());
        }

        
    }
    public override void Exit()
    {
        enemy.enemyRigid.useGravity = false;
    }

}