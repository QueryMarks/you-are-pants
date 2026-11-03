using UnityEngine;

public class PlayerState : State
{
    //Player player;
    public override void Enter()
    {
        //run the base state enter
        base.Enter();
        stateName = "playerState";
        //add the player's scripts, such as:
        //player = myObject.GetComponent<Player>();
        
    }

    public override void TakeDamage(Damager damager)
    {
        //player's reaction to damage
        if (!myObject.GetComponent<Health>().LoseHealth(damager.damage))
        {
            Debug.Log("I AM THE PLAYER, AND I HAVE DIED.");
            //insert resetting level logic in a player method, such as:
            
            //player.Die();
        }
        //if this state should be stunnable, include logic here, such as
        //StateMachine.ChangeState(new PlayerStunState());
    }
}
