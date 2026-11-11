using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
    [SerializeField] Vector2 rightSpot;
    
    bool state = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the box I am assigned to is ontop of me
        //Change my state to true! - meaning the the thing is complete!

        //Debug.Log(transform.position.ToString() + "\n" + rightSpot.ToString());

        if(transform.position.x >= rightSpot.x && transform.position.x <= rightSpot.x + 1)
        {
            //I am within the right spot on the X!
            if(transform.position.y >= rightSpot.y && transform.position.y <= rightSpot.y + 1)
            {
                //I am within the right spot on both X and Y!
                state = true;
                Debug.Log("I am in the right spot!");
            }
            else
            {
                state = false;
            }

        }
        else
        {
            state = false;
        }
    }

    public bool GetButtonState()
    {
        return state;
    }
}
