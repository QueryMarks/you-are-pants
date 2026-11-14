using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float loadDelay = 0.5f;

    public bool canWin = false;

    static public int maxEnemies;
    static private int deadEnemies = 0;

    private String nextLevel = null;

    public void Awake()
    {
            
    }

    public void Start()
    {
       maxEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Debug.Log("Number of enemies found in level! " + maxEnemies);
    }

    public void LateUpdate()
    {
        if(deadEnemies >= maxEnemies)
        {
            canWin = true;
        }
        //Debug.Log("Enemies to kill: " + maxEnemies);
    }


    public void LoadNextLevel()
    {
        Invoke(nameof(Load), loadDelay);
    }

    void Load()
    {
        //why on earth were we doing the below? -Ethelyn
        //Time.timeScale = 0.5f;

        SceneManager.LoadScene("ResultScene");
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
