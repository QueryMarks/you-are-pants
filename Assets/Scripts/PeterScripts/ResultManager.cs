using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TMP_Text resultTitle;
    public TMP_Text healthText;
    public TMP_Text timeText;
    public TMP_Text comboText;

    public void ShowResults(bool won, int health, float time, int highestCombo)
    {
        //Peter: The following has placeholders, must call functions to properly display text.
        resultTitle.text = won ? "YOU WIN!" : "YOU LOSE!"; //P: properly define how the player wins or loses to show the result
        
        healthText.text = "HEALTH: " + health; //P: replace with health function from player
        timeText.text = "TIME: " + FormatTime(time); //P: create a timer function
        comboText.text = "HIGHEST COMBO: x" + highestCombo; //P: create a function that is called here that counts the highest combo
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void Retry()
    {
        //Time.timeScale = 0.5f;
        SceneManager.LoadScene("StartScene");
    }
}