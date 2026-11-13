using UnityEngine;

public class PlayerAttack: PlayerState
{
    public string anim;
    public Animator animator;
    public override void Enter()
    {
        base.Enter();
        animator = player.GetComponent<Animator>();
        animator.SetTrigger(anim);
    }
    public override void Exit()
    {
        player.cancelCheck = false;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && player.cancelCheck)
        {
            AttackCancel();
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            if (player.IsGrounded())
            {
                player.Land();
                stateMachine.ChangeState(new PlayerIdle());
            }
            else
            {
                stateMachine.ChangeState(new PlayerFall());
            }
            
        }
    }

    public virtual void AttackCancel()
    {

    }
}
