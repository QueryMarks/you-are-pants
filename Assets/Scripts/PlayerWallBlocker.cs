using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWallBlocker : MonoBehaviour
{
    public enum PuzzleType
    {
        PT_ERROR,
        PT_KILL_NUM_ENEMIES,
        PT_PUZZLE_BOX,
    }

    [SerializeField] PuzzleType pt;
    private bool isDead = false;

    public int numToDie = 0;

    [SerializeField] GameObject[] buttons;

    private int numBoxesTrue = 0;
    private int maxNumBoxesTrue = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch(pt)
        {
            case PuzzleType.PT_KILL_NUM_ENEMIES:
                //Nothing more needs to be done here! - ME
                if(numToDie == 0)
                {
                    Debug.LogError("Make sure to set the number of enemies that need to die before I die!");
                }

                break;

            case PuzzleType.PT_PUZZLE_BOX:

                if(buttons.Length == 0)
                {
                    Debug.LogError("Make sure to set the button GameObjects in the editor! I have 0!");
                    pt = PuzzleType.PT_ERROR;
                }

                maxNumBoxesTrue = buttons.Length;

                foreach(GameObject obj in buttons)
                {
                    if(obj.GetComponent<PuzzleButtons>() == null)
                    {
                        Debug.LogError("At least 1 puzzle box given to wall breaker does not have the Puzzle Button Script!");
                        pt = PuzzleType.PT_ERROR;
                    }
                }

                break;

            default:

                Debug.Log("Unkown Puzzle Type for destroyable wall!");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(pt)
        {
            case PuzzleType.PT_KILL_NUM_ENEMIES:

               if(numToDie <= LevelManager.getDead())
                {
                    isDead = true;
                }

                break;

            case PuzzleType.PT_PUZZLE_BOX:

                //Loop through boxs and check if they are in the right spot!
                foreach(GameObject obj in buttons)
                {
                    if(obj.GetComponent<PuzzleButtons>())
                    {
                        if(obj.GetComponent<PuzzleButtons>().GetButtonState() == true)
                        {
                            numBoxesTrue++;
                        }
                    }
                    else
                    {
                        //Debug.LogError("ERERERER");
                    }

                }

                if(numBoxesTrue == maxNumBoxesTrue)
                {
                    isDead = true;
                }
                else
                {
                    numBoxesTrue = 0;

                }
                
                break;

            case PuzzleType.PT_ERROR:

                Debug.LogError("Wall blocker in the error state!");
                break;

            default:

                Debug.Log("Unkown Puzzle Type for destroyable wall!");
                break;
        }
        


        if(isDead == true)
        {
            //Disable the self!
            CleanUp();
           
        }
    }

    
    private void CleanUp()
    {
        switch(pt)
        {
            case PuzzleType.PT_PUZZLE_BOX:

                //We can remove this later if we do not want the puzzle boxes to be destroyed
                //I am including this as the default case to help prevent any weird things got stuck events where the boxes landed
                //In wrong spots and block the player from progressing - ME

                foreach(GameObject obj in buttons)
                {
                    Destroy(obj);
                }

                Destroy(gameObject);
                break;

            default:
                Destroy(gameObject);
               
                break;
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
