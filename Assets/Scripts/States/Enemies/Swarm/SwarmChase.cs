using UnityEngine;
using UnityEngine.UIElements;
public class SwarmChase : SwarmState
{
    int timer = 0;

    public override void Enter()
    {
        base.Enter();
        enemy.enemyRigid.linearVelocity = Vector3.zero;
        
    }

    public override void FixedUpdate()
    {
        //face player
        if ((enemy.gameObject.transform.position.x < enemy.player.gameObject.transform.position.x))
        {
            swarm.Face(true);
        }
        else if ((enemy.gameObject.transform.position.x > enemy.player.gameObject.transform.position.x))
        {
             swarm.Face(false);
        }

        if (Mathf.Abs(enemy.gameObject.transform.position.x - enemy.player.gameObject.transform.position.x) > swarm.chaseDistance)
        {
            stateMachine.ChangeState(new SwarmIdle());
        }
        else if (Mathf.Abs(enemy.gameObject.transform.position.x - enemy.player.gameObject.transform.position.x) <= swarm.attackDistance)
        {
            Vector3 target = new Vector3(enemy.player.transform.position.x, enemy.player.transform.position.y, enemy.player.transform.position.z);

            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, swarm.chaseSpeed * Time.deltaTime);
            if (Mathf.Abs(enemy.gameObject.transform.position.x - enemy.player.gameObject.transform.position.x) <= swarm.chaseDistance)
            {
                timer += 1;
                if (timer >= 120)
                {
                    stateMachine.ChangeState(new SwarmAttack());
                }
            }
            else
            {
                timer = 0;
            }
        }
    }

}