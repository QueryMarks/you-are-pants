using UnityEngine;

public class ShooterAttack : ShooterState
{
    int timer = 0;
    // Use this for initialization
    public override void Enter()
    {
        base.Enter();
        shoot.hitbox.SetActive(true);
        shoot.animator.SetTrigger("Attack");
        enemy.enemyRigid.linearVelocity = Vector3.Normalize(enemy.player.transform.position - enemy.transform.position) * shoot.attackSpeed;
    }
    public override void FixedUpdate()
    {
        timer += 1;
        if (timer >= 45)
        {
            stateMachine.ChangeState(new ShooterIdle());
        }
    }
    public override void Exit()
    {
        shoot.animator.SetTrigger("Idle");
        shoot.hitbox.SetActive(false);
    }

}