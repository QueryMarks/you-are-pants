using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health health;
    public Animator animator;
    public Rigidbody enemyRigid;
    public StateMachine stateMachine;
    public int facing = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        health.BasicDie();
    }
    public void Face(bool faceRight)
    {
        if (faceRight)
        {
            facing = 1;
            
        }
        else
        {

            facing = -1;
        }
        myObject.transform.localScale = new Vector3(facing, 1, 1);
    }
}
