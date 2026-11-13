using Unity.VisualScripting;
using UnityEngine;

public class UpdateLevelManager : MonoBehaviour
{
    LevelManager levelManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        if(levelManager == null)
        {
            Debug.Log("Cannot find the Level Manager in UpdateLevelManager!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider toucher)
    {
        
        if(toucher.tag == "ThePlayer")
        {
           
            levelManager.TellLevelCanWin();
        }
    }
}
