using UnityEngine;
using System.Collections;

public class ShooterState : EnemyState
{
    public ShooterEnemy swarm;

    public override void Enter()
    {
        base.Enter();
        if (enemy is ShooterEnemy)
        {
            swarm = (ShooterEnemy)enemy;
        }
        
    }
    public override void FixedUpdate()
    {

    }

    public override void TakeDamage(Damager damager)
    {
        if (!myObject.GetComponent<Health>().LoseHealth(damager.damage))
        {
            Debug.Log("I AM AN ENEMY, AND I HAVE DIED.");
            //enemy.Die();
            enemy.health.BasicDie();
        }
        enemy.health.TakeKnockback(damager);
        stateMachine.ChangeState(new ShooterHurt());
    }
}
