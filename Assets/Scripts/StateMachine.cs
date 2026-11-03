using UnityEngine;

public class StateMachine : MonoBehaviour
{
    GameObject myObject;
    [SerializeField] State currentState;
    public State startState;

    void Start()
    {
        myObject = this.gameObject;

    }

    void StateInit()
    {
        if (startState != null)
        {
            currentState = startState;
        }
        startState.myObject = myObject;
        startState.stateMachine = this;
        startState.Enter();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeState(State state)
    {
        currentState.Exit();
        startState = state;
        startState.myObject = myObject;
        startState.stateMachine = this;
        startState.Enter();
    }
    
    public void TakeDamage(Damager damage)
    {
        currentState.TakeDamage(damage);
    }
    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }
    void FixedUpdate()
    {
        currentState.FixedUpdate();
    }
}
