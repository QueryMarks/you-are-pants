using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] float hpGain = 5;
    public override void Activate(Player player)
    {
        player.GainHealth(hpGain);
        base.Activate(player);
    }
}
