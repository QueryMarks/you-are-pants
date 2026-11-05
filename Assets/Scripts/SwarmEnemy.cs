using UnityEngine;

public class SwarmEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        stateMachine.StateInit(new SwarmIdle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
