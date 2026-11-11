using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    //movement variables
    public float movePower = 2f;
    public float moveAccel = 1f;
    public float maxJumpHeight = 10f;
    public float jumpPower = 10f;

    public Health health;
    public Animator animator;
    public Rigidbody playerRigid;

    public StateMachine stateMachine;

    private GameObject myObject;

    public int facing = 1;

    public int combo = 0;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI healthText;
    


    //A bool used for cancelling attacks in combos early. Set/unset by the animator, and checked/unset by the player's state.
    public bool cancelCheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myObject = this.gameObject;
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        //Debug.Log("welcome to my awesome player start");
        playerRigid = GetComponentInChildren<Rigidbody>();

        if(playerRigid == null)
        {
            Debug.LogError("Failed to find the player's rigid body component!");
        }
        stateMachine = GetComponent<StateMachine>();
        if (stateMachine != null)
        {
            stateMachine.StateInit(new PlayerIdle());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("IT JUMPS IN THE NORMAL PLAYER WORLD");
        }    
    }

    public void Die()
    {
        //Debug.Log("PLAYER SCRIPT! i have died");
        SceneManager.LoadScene("ResultScene");
    }

    public bool IsGrounded()
    {
        Collider col = transform.GetComponentInChildren<Collider>();
        Ray ray = new Ray(col.bounds.center,Vector3.down);
        float radius = col.bounds.extents.x - 0.05f;
    
        float fullDistance = col.bounds.extents.y + 0.05f;
        return Physics.SphereCast(ray,radius,fullDistance);
    }

    //default movement behavior, only run when called by the current state
    public void DefaultMove()
    {
        Vector3 newVelocity = playerRigid.linearVelocity;

        
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Mathf.Abs(newVelocity.x + (Input.GetAxisRaw("Horizontal") * moveAccel)) >= movePower)
            {
                newVelocity.x = Input.GetAxisRaw("Horizontal") * movePower;
            }
            else
            {
                newVelocity.x += Input.GetAxisRaw("Horizontal") * moveAccel;
            }
            
        }
        playerRigid.linearVelocity = newVelocity;
    }

    public bool JumpCheck()
    {
        if (IsGrounded() == true)
        {
            //Allow jump
            //Debug.Log("Jumping time. am i jumping?");
            if (Input.GetKey(KeyCode.Space))
            {
                //Debug.Log("I am jumping");
                return true;
            }

            
            return false;
        }
        else return false;
    }

    //-1 for face left,
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

    public void UpdateCombo(int amount)
    {
        combo = amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        comboText.text = "Combo: " + combo.ToString();
        healthText.text = "Health: " + health.health.ToString();
    }
}
