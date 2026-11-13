using Unity.VisualScripting;
using UnityEngine;
public class PlayerIdle : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        player.animator.SetTrigger("Idle");
        //playerRigid.linearVelocity = new Vector3(0, playerRigid.linearVelocity.y;
    }
    public override void FixedUpdate()
    {
        if (player.transform.localScale.y != 1)
        {
            float rescale = Mathf.Lerp(player.transform.localScale.y, 1f, 0.001f);
            player.transform.localScale = new Vector3(player.facing, rescale, 1);
        }
        if (!player.IsGrounded())
        {
            stateMachine.ChangeState(new PlayerFall());
        }
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            stateMachine.ChangeState(new PlayerRun());
        }
    }

    public override void Update()
    {
        //Debug.Log("welcome to my awesome idle state update");
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
}