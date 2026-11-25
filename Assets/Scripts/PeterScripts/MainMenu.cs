using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public Slider musicSlider;
    public Slider sfxSlider;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("P-TestLevel Puzzle");
    }
    public void OpenOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        musicSlider.SetValueWithoutNotify(FindFirstObjectByType<MusicManager>().GetVolume());

        sfxSlider.SetValueWithoutNotify(FindFirstObjectByType<SoundEffectManager>().GetVolume());
        FindFirstObjectByType<MusicManager>().ConnectSlider(musicSlider);
        FindFirstObjectByType<SoundEffectManager>().ConnectSlider(sfxSlider);
    }

    public void BackButton()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
