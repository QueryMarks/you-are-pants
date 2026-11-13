using System.Collections;
using UnityEngine;
public class PlayerRun : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        player.animator.SetTrigger("Run");
    }
    // Update is called once per frame
    public override void FixedUpdate()
    {

        if (player.transform.localScale.y != 1)
        {
            float rescale = Mathf.Lerp(player.transform.localScale.y, 1f, 0.05f);
            player.transform.localScale = new Vector3(player.facing, rescale, 1);
        }
        if (!player.IsGrounded())
        {
            stateMachine.ChangeState(new PlayerFall());
        }
        Vector3 newVelocity = playerRigid.linearVelocity;

        
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            playerRigid.linearVelocity = new Vector3(0, playerRigid.linearVelocity.y, 0);
            stateMachine.ChangeState(new PlayerIdle());
        }
        else
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
}