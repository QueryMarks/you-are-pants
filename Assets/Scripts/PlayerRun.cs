using System.Collections;
using UnityEngine;
public class PlayerRun : PlayerState
{
    // Update is called once per frame
    public override void FixedUpdate()
    {
         Vector3 newVelocity = playerRigid.linearVelocity;

        
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            stateMachine.ChangeState(new PlayerIdle());
        }
        else
        {
            player.DefaultMove();
        }    
            
    }
}