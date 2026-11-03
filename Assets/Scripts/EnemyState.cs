using UnityEngine;

public class enemyState : State
{
    //reference to enemy here;
    //Enemy enemy;
    public override void Enter()
    {
        //run the base state enter
        base.Enter();
        stateName = "enemyState";
        //add the enemy's scripts, such as:
        //enemy = myObject.GetComponent<Enemy>();
        
    }

    public override void TakeDamage(Damager damager)
    {
        //enemy's reaction to damage
        if (!myObject.GetComponent<Health>().LoseHealth(damager.damage))
        {
            Debug.Log("I AM AN ENEMY, AND I HAVE DIED.");
            //enemy.Die();
            Object.Destroy(myObject);
        }
        //if this state should be stunnable, include logic here, such as
        //StateMachine.ChangeState(new EnemyStunState());
    }
}
