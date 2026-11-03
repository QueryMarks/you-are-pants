using UnityEngine;
public class PlayerIdle : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        //playerRigid.linearVelocity = new Vector3(0, playerRigid.linearVelocity.y;
    }
    public override void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            stateMachine.ChangeState(new PlayerRun());
        }
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("JUMP IT!!!");
        }
        //Debug.Log("welcome to my awesome idle state update");
        if (player.JumpCheck() == true)
        {
            Debug.Log("Switching to JUMP!!!!");
            stateMachine.ChangeState(new PlayerJump());
        }
    }
}