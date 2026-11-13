using System.Collections;
using UnityEngine;

public class PlayerJab : PlayerAttack
{
    int sequence = 0;
    public override void Enter()
    {
        //slide attack, may move to custom state for behavior with a more elaborate input reader
        if (Input.GetKey(KeyCode.DownArrow))
        {
            
            anim = "Slide";
            base.Enter();
            player.gameObject.transform.localScale = new Vector3(player.facing * 1.5f, 0.5f, player.transform.localScale.z);
            player.playerRigid.linearVelocity = new Vector3(player.facing * 10, -2, 0);
            //prevent further follow ups
            sequence = 2;
        }
        //non slide attack
        else
        { 
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
        }    

        animator.SetTrigger(anim);
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

    public override void Exit()
    {
        base.Exit();
        player.gameObject.transform.localScale = new Vector3(player.facing, 1, player.transform.localScale.y);
    }
}