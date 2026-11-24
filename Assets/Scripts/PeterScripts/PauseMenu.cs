using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ResumeButtom()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
