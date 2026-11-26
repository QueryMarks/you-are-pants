using System;
using TMPro;
using UnityEngine;

public class UI_Script : MonoBehaviour
{
    [SerializeField] Canvas menu = null;

    [SerializeField] TMP_Text health;
    [SerializeField] TMP_Text combo;
    [SerializeField] TMP_Text timer;
    public float elapsedTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimer(elapsedTime);
    }

    public void UpdateHP(int num)
    {
        health.text = "HP: " + num;
    }

    public void UpdateCombo(int num)
    {
        combo.text = "Combo: " + num;
    }
    public void UpdateTimer(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        timer.text = string.Format(
            "{0:00}:{1:00}:{2:000}",
            minutes, seconds, milliseconds
        );
    }
    public float GetTime()
    {
        return elapsedTime;
    }
}
