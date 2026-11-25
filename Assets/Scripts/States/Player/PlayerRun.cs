using System.Collections;
using UnityEngine;
public class PlayerRun : PlayerState
{
    private bool playingFootsteps = false;
    public float footstepSpeed = 0.5f;
    private Coroutine footstepCoroutine;
    public override void Enter()
    {
        base.Enter();
        player.animator.SetTrigger("Run");
    }
    // Update is called once per frame
    public override void FixedUpdate()
    {

        if (player.transform.localScale.y != 1)
        {
            float rescale = Mathf.Lerp(player.transform.localScale.y, 1f, 0.05f);
            player.transform.localScale = new Vector3(player.facing, rescale, 1);
        }
        if (!player.IsGrounded())
        {
            StopFootsteps();
            stateMachine.ChangeState(new PlayerFall());
            return;
        }
        Vector3 newVelocity = playerRigid.linearVelocity;

        
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            StopFootsteps();
            playerRigid.linearVelocity = new Vector3(0, playerRigid.linearVelocity.y, 0);
            stateMachine.ChangeState(new PlayerIdle());
        }
        else
        {
            player.DefaultMove();

            StartFootsteps();
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                player.Face(false);
            }
            else
            {
                player.Face(true);
            }
        }    
            
    }
    void StartFootsteps()
    {
        if (!playingFootsteps)
        {
            playingFootsteps = true;
            footstepCoroutine = player.StartCoroutine(PlayFootsteps());
        }
    }

    void StopFootsteps()
    {
        if (playingFootsteps)
        {
            playingFootsteps = false;
            player.StopCoroutine(footstepCoroutine);
            footstepCoroutine = null;
        }
        SoundEffectManager.StopRun();
    }

    IEnumerator PlayFootsteps()
    {
        while (true)
        {
            SoundEffectManager.PlayRun();
            yield return new WaitForSeconds(footstepSpeed);
        }
    }
    public override void Update()
    {
        if (player.JumpCheck() == true)
        {
            StopFootsteps();
            //Debug.Log("Switching to JUMP!!!!");
            stateMachine.ChangeState(new PlayerJump());
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            StopFootsteps();
            stateMachine.ChangeState(new PlayerJab());
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.ChangeState(new PlayerParry());
        }
    }
}