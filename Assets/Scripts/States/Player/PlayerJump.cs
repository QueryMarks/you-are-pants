using System.Collections;
using UnityEngine;
public class PlayerJump : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        Vector3 newVelocity = playerRigid.linearVelocity;
        newVelocity.y = player.jumpPower = 10f;
        playerRigid.linearVelocity = newVelocity;
    }

    public override void FixedUpdate()
    {
        player.DefaultMove();
        if (player.IsGrounded() && player.playerRigid.linearVelocity.y <= 0)
        {
            stateMachine.ChangeState(new PlayerIdle());
        }
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.ChangeState(new PlayerJab());
        }
    }
}