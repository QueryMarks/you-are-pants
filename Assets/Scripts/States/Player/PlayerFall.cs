using System.Collections;
using UnityEngine;
public class PlayerFall : PlayerState
{
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