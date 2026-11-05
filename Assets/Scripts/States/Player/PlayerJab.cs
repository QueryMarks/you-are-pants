using System.Collections;
using UnityEngine;

public class PlayerJab : PlayerAttack
{
    int sequence = 0;
    public override void Enter()
    {
        //before base Enter initialization
        switch (sequence)
        {
            case 0:
                anim = "Jab";
                break;
            case 1:
                anim = "Jab2";
                break;
            case 2:
                anim = "Jab3";
                break;
            default:
                break;

        }
        base.Enter();
        //after base Enter initialization
        switch (sequence)
        {
            case 0:
                player.playerRigid.linearVelocity = new Vector3(player.facing, 0, 0);
                break;
            case 1:
                player.playerRigid.linearVelocity = new Vector3(player.facing * 3, 0, 0);
                break;
            case 2:
                player.playerRigid.linearVelocity = new Vector3(player.facing * 5, 10, 0);
                break;
            default:
                break;

        }
        animator.SetTrigger(anim);
    }
    public override void Exit()
    {
        
    }
    public override void AttackCancel()
    {
        if (sequence < 2)
        {
            PlayerJab jabState = new PlayerJab();
            jabState.sequence = sequence + 1;
            stateMachine.ChangeState(jabState);
        }
    }
}