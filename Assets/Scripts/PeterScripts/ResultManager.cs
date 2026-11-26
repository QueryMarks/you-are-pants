using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text comboText;
    public TMP_Text timerText;

    void Start()
    {
        healthText.text = "HEALTH: " + GameManager.instance.finalHealth;
        comboText.text = "HIGHEST COMBO: " + GameManager.instance.finalCombo;

        int minutes = Mathf.FloorToInt(GameManager.instance.finalTime / 60f);
        int seconds = Mathf.FloorToInt(GameManager.instance.finalTime % 60f);
        int milliseconds = Mathf.FloorToInt((GameManager.instance.finalTime * 1000f) % 1000f);

        timerText.text = "TIME: " + string.Format("{0:00}:{1:00}:{2:000}",
            minutes, seconds, milliseconds);
    }
    public void Retry()
    {
        SceneManager.LoadScene("StartScene");
        MusicManager.PlayBackgroundMusic(true);
    }
}