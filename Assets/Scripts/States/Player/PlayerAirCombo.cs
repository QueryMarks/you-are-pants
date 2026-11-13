using UnityEngine;

public class PlayerAirCombo : PlayerAttack
{
    int sequence = 0;

    public override void Enter()
    {
        //slide attack, may move to custom state for behavior with a more elaborate input reader
        if (Input.GetKey(KeyCode.DownArrow))
        {
            
            anim = "Slide";
            base.Enter();
            //player.gameObject.transform.localScale = new Vector3(player.facing * 1.5f, 0.5f, player.transform.localScale.z);
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
                    anim = "AirCombo";
                    break;
                case 1:
                    anim = "AirCombo2";
                    break;
                case 2:
                    anim = "AirCombo3";
                    break;
                default:
                    break;

            }
            
            base.Enter();
            //after base Enter initialization
            switch (sequence)
            {
                case 0:
                    player.playerRigid.linearVelocity = new Vector3(player.facing, 2, 0);
                    break;
                case 1:
                    player.playerRigid.linearVelocity = new Vector3(player.facing * 5, 2, 0);
                    break;
                case 2:
                    player.playerRigid.linearVelocity = new Vector3(player.facing * 10, 4, 0);
                    player.playerRigid.useGravity = false;
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
            PlayerAirCombo airComboState = new PlayerAirCombo();
            airComboState.sequence = sequence + 1;
            stateMachine.ChangeState(airComboState);
        }
    }
    public override void Exit()
    {
        base.Exit();
        player.playerRigid.useGravity = true;
        //player.gameObject.transform.localScale = new Vector3(player.facing, 1, player.transform.localScale.y);
    }
    
}
