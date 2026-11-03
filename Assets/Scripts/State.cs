using UnityEngine;

public class State
{
    //Variables probably used by every state
    //add Player when we have that script
    //Player player;
    public GameObject myObject;
    public Animator animator;
    public StateMachine stateMachine;

    //used for debugging
    public string stateName;

    
    public virtual void Enter()
    {
        animator = myObject.GetComponent<Animator>();
    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void TakeDamage(Damager damager)
    {
        myObject.GetComponent<Health>().LoseHealth(damager.damage);
    }

    public virtual void FixedUpdate()
    {

    }
}
