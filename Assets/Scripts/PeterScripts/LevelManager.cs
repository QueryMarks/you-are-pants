using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float loadDelay = 0.5f;

    public bool canWin = false;

    static public int maxEnemies;
    static private int deadEnemies = 0;

    private String nextLevel = null;

    [SerializeField] TextMeshProUGUI thing = null;

    private UI_Script ui;

    public void Awake()
    {
            
    }

    public void Start()
    {     
       deadEnemies = 0;
       maxEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
       //Debug.Log("Number of enemies found in level! " + maxEnemies);

       if(thing == null)
       {
           //Go find it
           Debug.Log("Level Manager does not have Enemies to kill Text Box!");
       }

       thing.text = "Enemies: " + maxEnemies +"\nDead: " + deadEnemies;

       
    }

    public void LateUpdate()
    {
        thing.text = "Enemies: " + maxEnemies +"\nDead: " + deadEnemies;
        if(deadEnemies >= maxEnemies)
        {
            canWin = true;
        }
        //Debug.Log("Enemies to kill: " + maxEnemies);
    }


    public void LoadNextLevel()
    {
        maxEnemies = 0;
        deadEnemies = 0;
        thing.text = "Enemies: " + maxEnemies +"\nDead: " + deadEnemies;

        Invoke(nameof(Load), loadDelay);
    }

    void Load()
    {
        //why on earth were we doing the below? -Ethelyn
        //Time.timeScale = 0.5f;

        


        maxEnemies = 0;
        deadEnemies = 0;

        thing.text = "Enemies: " + maxEnemies +"\nDead: " + deadEnemies;
        Player player = FindFirstObjectByType<Player>();
        UI_Script ui = FindFirstObjectByType<UI_Script>();

        if (player != null && ui != null && GameManager.instance != null)
        {
            GameManager.instance.SaveResults(player.GetHP(), player.GetCombo(), ui.GetTime());

            Debug.Log("Results saved before winning!");
        }
        else
        {
            Debug.LogError("Could not find Player, UI_Script, or GameManager!");
        }

        SceneManager.LoadScene("WinScene");
        
        MusicManager.PauseBackgroundMusic();

        //SceneManager.LoadScene("");
    }

    static public void updateDead()
    {
        deadEnemies++;
    }

    static public int getDead()
    {
        return deadEnemies;
    }

    static public void giveEnemies(int inEnemies)
    {
        //Debug.Log("Got: " + inEnemies);
        maxEnemies += inEnemies;
    }

    public void changeLevel(String inLevel)
    {
        nextLevel = inLevel;
    }

    public void TellLevelCanWin()
    {
        canWin = true;
    }

    public bool getLevelCanWin()
    {
        return canWin;
    }
}
