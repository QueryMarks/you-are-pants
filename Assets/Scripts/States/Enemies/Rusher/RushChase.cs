using UnityEngine;
using UnityEngine.UIElements;
public class RushChase : RusherState
{
    int timer = 0;
    int offset = 5;
    float trueOffset;

    public override void Enter()
    {
        base.Enter();
        enemy.enemyRigid.linearVelocity = Vector3.zero;
        trueOffset = offset;
        
    }

    public override void FixedUpdate()
    {
        Collider col;
        Ray ray;
        RaycastHit hit;

        trueOffset = offset;

        //face player
        if ((enemy.gameObject.transform.position.x < enemy.player.gameObject.transform.position.x))
        {
            rush.Face(true);
        }
        else if ((enemy.gameObject.transform.position.x > enemy.player.gameObject.transform.position.x))
        {
             rush.Face(false);
        }

        if (Mathf.Abs(enemy.gameObject.transform.position.x - enemy.player.gameObject.transform.position.x) > rush.chaseDistance)
        {
            stateMachine.ChangeState(new RusherIdle());
        }
        else if (Mathf.Abs(enemy.gameObject.transform.position.x - enemy.player.gameObject.transform.position.x) <= rush.attackDistance)
        {

            //Shoot a beam upwards
            //If beam distance.y < offset, only move up to the offset -1
            
            col = rush.GetComponentInChildren<Collider>();
            //ray = new Ray(col.bounds.center,Vector3.up);
            

            if(Physics.Raycast(col.bounds.center,rush.transform.up, out hit, offset))
            {
                //Debug.Log("There is something above Rusher!");
                trueOffset = offset - hit.transform.position.y;
            }

            Vector3 target = new Vector3(enemy.player.transform.position.x, enemy.transform.position.y + trueOffset, enemy.player.transform.position.z);
            
           

            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, (rush.chaseSpeed + timer/10) * Time.deltaTime);

            if (Mathf.Abs(enemy.gameObject.transform.position.x - enemy.player.gameObject.transform.position.x) <= rush.chaseDistance)
            {
                timer += 1;
                if (timer >= 120)
                {
                    stateMachine.ChangeState(new RushAttack());
                }
            }
            else
            {
                timer = 0;
            }
        }
    }

}