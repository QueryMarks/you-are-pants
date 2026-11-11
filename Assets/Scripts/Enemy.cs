using UnityEngine;
using TMPro;

public abstract class Enemy : MonoBehaviour
{
    public Health health;
    public Animator animator;
    public Rigidbody enemyRigid;
    public StateMachine stateMachine;
    private GameObject myObject;
    public GameObject player;
    public int facing = 1;

    private TextMeshProUGUI tmp;

    private GameObject hpCon;
    private  RectTransform rect;

    private float currentHealth;
    private float maxHealth;
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
        health = this.gameObject.GetComponent<Health>();
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
        enemyRigid = GetComponent<Rigidbody>();
        myObject = this.gameObject;

        

        //Debug.Log("NAME: "+myObject.name+"\nPosition: " + myObject.transform.position);
        maxHealth = health.GetHealth();
        currentHealth = maxHealth;

        hpCon = new GameObject("Enemy HP");
        hpCon.transform.SetParent(FindAnyObjectByType<Canvas>().transform,false);
        tmp = hpCon.AddComponent<TextMeshProUGUI>();

        tmp.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        tmp.fontSize = 36;
        tmp.color = Color.white;
        tmp.transform.localPosition = new Vector3(myObject.transform.position.x,myObject.transform.position.y + 1.5f,myObject.transform.position.z);//new Vector3(0, 1.5f, 0);
        //Debug.Log(tmp.transform.position);
        
        tmp.transform.rotation = Quaternion.identity;
        tmp.alignment = TextAlignmentOptions.Center;

        rect = hpCon.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(300, 100);
        rect.anchoredPosition = Vector2.zero;
        rect.transform.localPosition =  new Vector3(myObject.transform.position.x,myObject.transform.position.y + 1.5f,myObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void FixedUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(myObject.transform.position + new Vector3(0, 1.5f, 0));
        currentHealth = health.GetHealth();
        tmp.text = currentHealth.ToString() + "/" + maxHealth.ToString();

        rect.position = screenPos;
    }

    public void Die()
    {
        tmp.gameObject.SetActive(false);
        rect.gameObject.SetActive(false);
        hpCon.gameObject.SetActive(false);
        
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
