using UnityEngine;
public class PlayerIdle : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerRigid.linearVelocity = Vector3.zero;
    }
    public override void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            stateMachine.ChangeState(new PlayerRun());
        }
    }
}