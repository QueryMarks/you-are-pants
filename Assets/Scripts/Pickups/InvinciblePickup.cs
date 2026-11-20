using UnityEngine;

public class InvinciblePickup : Pickup
{
    public override void Activate(Player player)
    {
        player.GoInvincible(300);
        base.Activate(player);
    }
}
