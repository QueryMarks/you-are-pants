using UnityEngine;

public class PlayerParry : PlayerAttack
{
    public override void Enter()
    {
        anim = "Parry";
        base.Enter();
        player.playerRigid.linearVelocity = new Vector3(player.playerRigid.linearVelocity.x, 2, 0);

    }
    public override void TakeDamage(Damager damager)
    {
        stateMachine.ChangeState(new PlayerParryAttack());
    }
}
