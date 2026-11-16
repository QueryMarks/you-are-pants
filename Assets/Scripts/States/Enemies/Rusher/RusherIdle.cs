using UnityEngine;
using System.Collections;

public class RusherIdle : RusherState
{

    public override void Enter()
    {
        base.Enter();
        
    }
    public override void FixedUpdate()
    {
        float dist = Mathf.Abs(enemy.gameObject.transform.position.x - enemy.player.gameObject.transform.position.x);
        //Debug.Log(dist);
        if (dist <= rush.chaseDistance)
        {
            stateMachine.ChangeState(new RushChase());
        }
        else
        {
            enemy.enemyRigid.linearVelocity = new Vector3(Mathf.Sin(Time.fixedTime), 0, 0);
        }

        
    }
}
