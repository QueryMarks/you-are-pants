using UnityEngine;

public class RushAttack : RusherState
{
    int timer = 0;
    // Use this for initialization
    public override void Enter()
    {
        base.Enter();
        rush.hitbox.SetActive(true);
        rush.animator.SetTrigger("Attack");
        enemy.enemyRigid.linearVelocity = Vector3.Normalize(enemy.player.transform.position - enemy.transform.position) * rush.attackSpeed;
    }
    public override void FixedUpdate()
    {
        timer += 1;
        if (timer >= 45)
        {
            stateMachine.ChangeState(new RusherIdle());
        }
    }
    public override void Exit()
    {
        rush.animator.SetTrigger("Idle");
        rush.hitbox.SetActive(false);
    }

}