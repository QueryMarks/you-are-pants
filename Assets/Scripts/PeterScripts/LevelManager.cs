using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float loadDelay = 0.5f;

    public bool canWin = false;

    public void OnCollisionEnter(Collision collision)
    {
        if(canWin == true)
        {
            Invoke(nameof(Load), loadDelay);
        }
        

    }
    public void LoadNextLevel()
    {
        Invoke(nameof(Load), loadDelay);
    }

    void Load()
    {
        Time.timeScale = 0.5f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
