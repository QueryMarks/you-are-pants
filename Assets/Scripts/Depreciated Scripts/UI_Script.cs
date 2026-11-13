using System;
using TMPro;
using UnityEngine;

public class UI_Script : MonoBehaviour
{
    [SerializeField] Canvas menu = null;

    [SerializeField] TMP_Text health;
    [SerializeField] TMP_Text combo;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHP(int num)
    {
        health.text = "HP: " + num;
    }

    public void UpdateCombo(int num)
    {
        combo.text = "Combo: " + num;
    }
}
