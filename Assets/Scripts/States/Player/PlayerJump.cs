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
        player.animator.SetTrigger("Jump");
    }

    public override void FixedUpdate()
    {
        player.DefaultMove();
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            player.Face(false);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            player.Face(true);
        }
        float stretch = playerRigid.linearVelocity.y;
        stretch = Mathf.Clamp(stretch, -15, 0);
        player.gameObject.transform.localScale = new Vector3(player.facing, -stretch * 0.05f + 1f, 1);
        if (player.playerRigid.linearVelocity.y <= 0)
        {
            if (player.IsGrounded())
            {
                player.Land();
                stateMachine.ChangeState(new PlayerIdle());
                player.transform.localScale = new Vector3(player.facing, 0.5f, 1);
            }
            else
            {
                stateMachine.ChangeState(new PlayerFall());
            }
        }

    }

    public override void Update()
    {
        if (player.JumpCheck() == true)
        {
            //Debug.Log("Switching to JUMP!!!!");

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