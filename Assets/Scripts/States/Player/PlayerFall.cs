using System.Collections;
using UnityEngine;
public class PlayerFall : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        player.animator.SetTrigger("Idle");
    }

    public override void FixedUpdate()
    {
        player.DefaultMove();
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            player.Face(false);
        }
        else
        {
            player.Face(true);
        }
        if (player.IsGrounded() && player.playerRigid.linearVelocity.y <= 0)
        {
            player.Land();
            stateMachine.ChangeState(new PlayerIdle());
        }
    }

    public override void Update()
    {
        if (player.JumpCheck() == true)
        {
            Debug.Log("Switching to JUMP!!!!");
            stateMachine.ChangeState(new PlayerJump());
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.ChangeState(new PlayerJab());
        }
    }
}