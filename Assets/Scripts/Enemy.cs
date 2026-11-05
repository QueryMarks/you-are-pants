using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Health health;
    public Animator animator;
    public Rigidbody enemyRigid;
    public StateMachine stateMachine;
    private GameObject myObject;
    public GameObject player;
    public int facing = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectsWithTag("ThePlayer")[0];

            if(player == null)
            {
                Debug.LogError("Failed to find the player!");
            }
        }
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
        enemyRigid = GetComponent<Rigidbody>();
        myObject = this.gameObject;
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
