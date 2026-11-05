using UnityEngine;

public class SwarmAttack : SwarmState
{
    int timer = 0;
    // Use this for initialization
    public override void Enter()
    {
        base.Enter();
        swarm.hitbox.SetActive(true);
        enemy.enemyRigid.linearVelocity = Vector3.Normalize(enemy.player.transform.position - enemy.transform.position) * swarm.attackSpeed;
    }
    public override void FixedUpdate()
    {
        timer += 1;
        if (timer >= 45)
        {
            stateMachine.ChangeState(new SwarmIdle());
        }
    }
    public override void Exit()
    {
        swarm.hitbox.SetActive(false);
    }

}