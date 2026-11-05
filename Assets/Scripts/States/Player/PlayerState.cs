using UnityEngine;

public class PlayerState : State
{
    public Player player;
    public Rigidbody playerRigid;
    public override void Enter()
    {
        //run the base state enter
        base.Enter();
        stateName = "playerState";
        //add the player's scripts, such as:
        player = myObject.GetComponent<Player>();
        playerRigid = player.playerRigid;
        
    }

    public override void TakeDamage(Damager damager)
    {
        //player's reaction to damage
        bool survivedDamage = player.health.LoseHealth(damager.damage);
        player.UpdateCombo(0);
        //player.UpdateUI();
        if (!survivedDamage)
        {
            Debug.Log("I AM THE PLAYER, AND I HAVE DIED.");
            //insert resetting level logic in a player method, such as:
            
            //player.Die();
        }
        else
        {
            PlayerHurt hurt = new PlayerHurt();
            player.health.TakeKnockback(damager);
            stateMachine.ChangeState(new PlayerHurt());
        }
        //if this state should be stunnable, include logic here, such as
        //StateMachine.ChangeState(new PlayerStunState());
    }
}
