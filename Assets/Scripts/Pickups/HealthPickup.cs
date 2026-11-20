using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] float hpGain;
    public override void Activate(Player player)
    {
        player.health.GainHealth(hpGain);
        base.Activate(player);
    }
}
