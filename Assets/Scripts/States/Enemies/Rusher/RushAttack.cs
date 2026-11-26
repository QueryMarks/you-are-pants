using UnityEngine;

public class RushAttack : RusherState
{
    int timer = 0;

    bool once = true;
    Vector3 startAttackPos = Vector3.zero;

    // Use this for initialization
    public override void Enter()
    {
        base.Enter();
        rush.hitbox.SetActive(true);
        rush.animator.SetTrigger("Attack");
        enemy.enemyRigid.linearVelocity = Vector3.Normalize(enemy.player.transform.position - enemy.transform.position) * rush.attackSpeed;
    }
    public override void FixedUpdate()
    {
        Collider col;
        RaycastHit hit;

        //col = rush.GetComponentInChildren<Collider>();

        if(once == true)
        {
            startAttackPos = enemy.transform.position;
            once = false;
        }

        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startAttackPos, (rush.chaseSpeed + timer/10) * Time.deltaTime);
       

        timer += 1;
        if (timer >= 45)
        {
            stateMachine.ChangeState(new RusherIdle());
            once = true;
        }
    }
    public override void Exit()
    {
        rush.animator.SetTrigger("Idle");
        rush.hitbox.SetActive(false);
    }

}