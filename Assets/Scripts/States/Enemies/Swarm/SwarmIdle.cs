using UnityEngine;
using System.Collections;

public class SwarmIdle : SwarmState
{

    public override void Enter()
    {
        base.Enter();
        
    }
    public override void FixedUpdate()
    {
        float dist = Mathf.Abs(Vector3.Distance(
            enemy.gameObject.transform.position,
            enemy.player.transform.position));
        //Debug.Log(dist);
        if (dist <= swarm.chaseDistance)
        {
            //Debug.Log("CHASE THE PLAYER DOWN!!!!!!");
            stateMachine.ChangeState(new SwarmChase());
        }
        else
        {
            enemy.enemyRigid.linearVelocity = new Vector3(0, Mathf.Sin(Time.fixedTime), 0);
        }

        
    }
}
