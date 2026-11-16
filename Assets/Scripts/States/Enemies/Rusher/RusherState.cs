using UnityEngine;
using System.Collections;

public class RusherState : EnemyState
{
    public RusherEnemy rush;

    public override void Enter()
    {
        base.Enter();
        if (enemy is RusherEnemy)
        {
            rush = (RusherEnemy)enemy;
        }
        
    }
    public override void FixedUpdate()
    {

    }

    public override void TakeDamage(Damager damager)
    {
        if (!myObject.GetComponent<Health>().LoseHealth(damager.damage))
        {
            Debug.Log("I AM A RUSHER ENEMY, AND I HAVE DIED.");
            //enemy.Die();
            enemy.health.BasicDie();
        }
        enemy.health.TakeKnockback(damager);
        stateMachine.ChangeState(new RushHurt());
    }
}
