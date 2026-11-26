using UnityEngine;

public class PlayerParryAttack : PlayerAttack
{
    public override void Enter()
    {
        anim = "ParryAttack";
        base.Enter();
    }
    public override void TakeDamage(Damager damager)
    {

    }
}
