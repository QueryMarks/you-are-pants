using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public GameObject optionsPanel;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsPanel.activeSelf)
            {
                BackButton();
            }
            else if (container.activeSelf)
            {
                ResumeButton();
            }
            else
            {
                container.SetActive(true);
                Time.timeScale = 0;
            }
            
        }
    }
    public void OpenOptions()
    {
        container.SetActive(false);
        optionsPanel.SetActive(true);
        musicSlider.SetValueWithoutNotify(FindFirstObjectByType<MusicManager>().GetVolume());

        sfxSlider.SetValueWithoutNotify(FindFirstObjectByType<SoundEffectManager>().GetVolume());
        FindFirstObjectByType<MusicManager>().ConnectSlider(musicSlider);
        FindFirstObjectByType<SoundEffectManager>().ConnectSlider(sfxSlider);
    }
    public void BackButton()
    {
        optionsPanel.SetActive(false);
        container.SetActive(true);
    }
    public void ResumeButton()
    {
        container.SetActive(false);
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
