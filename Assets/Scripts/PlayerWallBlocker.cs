using UnityEngine;

public class PlayerWallBlocker : MonoBehaviour
{
    bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            //Disable the self!
            gameObject.SetActive(false);
        }
    }

    void setIsDead(bool inStatus)
    {
        isDead = inStatus;
    }

    bool getIsDead()
    {
        return isDead;
    }
}
