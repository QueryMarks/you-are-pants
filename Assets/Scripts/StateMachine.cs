using UnityEngine;

public class StateMachine : MonoBehaviour
{
    GameObject myObject;
    [SerializeField] State currentState;
    //public State startState;

    void Start()
    {
        myObject = this.gameObject;
    }

    public void StateInit(State startState)
    {
        if (startState != null)
        {
            currentState = startState;
        }
        startState.myObject = this.gameObject;
        startState.stateMachine = this;
        startState.Enter();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeState(State state)
    {
        currentState.Exit();
        currentState = state;
        currentState.myObject = myObject;
        currentState.stateMachine = this;
        currentState.Enter();
    }
    
    public void TakeDamage(Damager damage)
    {
        currentState.TakeDamage(damage);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Updating current state.");
        currentState.Update();
        if (currentState is DeadState)
        {
            Debug.Log("Dead state reached.");
        }
    }
    void FixedUpdate()
    {
        currentState.FixedUpdate();
    }
}
