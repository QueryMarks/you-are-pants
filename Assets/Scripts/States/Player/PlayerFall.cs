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
            player.transform.localScale = new Vector3(player.facing, 0.5f, 1);
        }
        else
        {
            player.gameObject.transform.localScale = new Vector3(player.facing, Mathf.Abs(playerRigid.linearVelocity.y) * 0.05f + 1f, 1);
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
    public override void Exit()
    {
        base.Exit();
        //player.gameObject.transform.localScale = new Vector3(player.facing, 1, 1);
    }
}