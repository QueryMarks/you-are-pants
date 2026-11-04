using UnityEngine;

public class PlayerAttack: PlayerState
{
    string anim;
    public override void Enter()
    {
        base.Enter();
        player.GetComponent<Animator>().SetTrigger(anim);
    }
}
