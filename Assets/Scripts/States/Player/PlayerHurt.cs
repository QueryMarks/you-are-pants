using System.Collections;
using UnityEngine;

public class PlayerHurt : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        animator.SetTrigger("Idle");
    }
    public override void FixedUpdate()
    {
        player.health.stunTimer -= 1;
        if (player.health.stunTimer <= 0)
        {
            stateMachine.ChangeState(new PlayerIdle());
        }
    }
}